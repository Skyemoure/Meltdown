using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
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

    public TextMeshProUGUI UIText;


    //Variables de velocidad, gravedad
    [SerializeField]
    private float playerSpeed = 2.0f;
    private float jumpHeight = 0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private float rotSpeed = 0.8f;

    //Número que marca el ritmo de movimiento, se usa para limitar la velocidad del player por el mismo número
    [SerializeField]
    private float timeSpeed = 0.08f;

    //anim
    public float animSpeed = 0f;

    public Transform prefabPos;

    private void Start()
    {
        //inicializo variables
        botellas = 5;
        //busco controller y el input de player creado
        controller = GetComponent<CharacterController>();
        input = GetComponent<PlayerInput>();
        moveAction = input.actions["Move"];
        //actuan diferentemente las mismas teclas segun las acciones activadas
        lookAction = input.actions["Look"]; 
        //camara
        camTransform = Camera.main.transform;

        //para que el cursor no salga de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        UIText.text = "X " + botellas.ToString();

        //botellas
        if (Input.GetMouseButton(1))
        {
            if (Input.GetMouseButtonDown(0) && botellas > 0)
            {
                //Creamos botellas al disparar
                //Si no golpea a nada sigue infinitamente (hasta que se le vá la vida útil y se autodestruye)
                RaycastHit hit;
                i = Instantiate(botella, prefabPos.transform.position, Quaternion.identity);
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

    private void FixedUpdate()
    {
        //chequeamos si hay piso
        groundedPlayer = controller.isGrounded;

        if(groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        //Leemos el input para mover al jugador según su rotación
        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        move = move.x * camTransform.right.normalized + move.z * camTransform.forward.normalized;
        move.y = 0;
        controller.Move(move * timeSpeed * playerSpeed);

        //Rotar personaje hacia la camara
        float targetAngle = camTransform.eulerAngles.y;
        Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotSpeed * timeSpeed);





       //Salto teórico si hubiera, ahora mismo no hace nada
       /* if (groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }*/

        //gravedad y límite
        playerVelocity.y += gravityValue * timeSpeed;
        if (playerVelocity.y < -15f)
        {
            playerVelocity.y = -15f;
        }
        

        controller.Move(playerVelocity * timeSpeed);

        animSpeed = move.magnitude;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Recargar botellas al agarrar más
        if (other.tag == "pickup")
        {
            botellas += 5;
            Destroy(other.gameObject);


        }
    }
}

