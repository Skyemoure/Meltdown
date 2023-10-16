using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class ControlCharacter1 : MonoBehaviour
{
    static public int botellas;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private PlayerInput input;
    private Transform camTransform;
    
    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction aimAction;

    public GameObject botella;
    Vector3 dir;
    GameObject i;
    public Transform mano;

    [SerializeField]
    private float playerSpeed = 2.0f;
    //private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private float rotSpeed = 0.8f;

    private void Start()
    {

        botellas = 5;
        controller = GetComponent<CharacterController>();
        input = GetComponent<PlayerInput>();
        moveAction = input.actions["Move"];
        lookAction = input.actions["Look"];
        camTransform = Camera.main.transform;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }


        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        move = move.x * camTransform.right.normalized + move.z * camTransform.forward.normalized;
        move.y = 0;
        controller.Move(move * Time.deltaTime * playerSpeed);

        //Rotar personaje hacia la camara
        float targetAngle = camTransform.eulerAngles.y;
        Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);

        /*
        // Changes the height position of the player..
        if (jumpAction.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }*/

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        //botellas
        if (Input.GetMouseButton(1))
        {
            if (Input.GetMouseButtonDown(0) && botellas > 0)
            {
                RaycastHit hit;
                i = Instantiate(botella, transform.position, Quaternion.identity);
                arrojarBotella bulletController = i.GetComponent<arrojarBotella>();
                if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, Mathf.Infinity))
                {
                    
                    
                    bulletController.target = hit.point;
                    bulletController.hit = true;

                    
                }
                else
                {
                    bulletController.target = camTransform.position + camTransform.forward * 25f;
                    bulletController.hit = true;
                }
                botellas--;
            }

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "pickup")
        {
            botellas += 5;
            Destroy(other.gameObject);


        }
    }
}

