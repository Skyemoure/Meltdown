using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class ControlCharacter1 : MonoBehaviour
{
    private Player_Cambio Camara;
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

    public Transform prefabPos;

    private void Start()
    {
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
        UIText = GameObject.FindWithTag("MainCamera").GetComponentInChildren<TextMeshProUGUI>();
        Camara = GameObject.FindWithTag("MainCamera").GetComponent<Player_Cambio>();
    }

    void Update()
    {
        UIText.text = "X " + Camara.botellas.ToString();

        //botellas
        if (Input.GetMouseButton(1))
        {
            if (Input.GetMouseButtonDown(0) && Camara.botellas > 0)
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
                Camara.botellas--;
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

        //gravedad y límite
        playerVelocity.y += gravityValue * timeSpeed;
        if (playerVelocity.y < -15f)
        {
            playerVelocity.y = -15f;
        }
        
        controller.Move(playerVelocity * timeSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Recargar botellas al agarrar más
        if (other.tag == "Pickup")
        {
            Camara.botellas += 3;
            Destroy(other.gameObject);
        }

        if (other.tag == "Zona_de_Calor")
        {
            playerSpeed = 1;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Recharge")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Camara.botellas = 5;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Zona_de_Calor")
        {
            playerSpeed = 2;
        }
    }

    public void EmpujarHaciaAtras(float fuerza)
    {
        Vector3 direccionOpuesta = -camTransform.forward;

        controller.Move(direccionOpuesta * fuerza * Time.deltaTime);
    }

}

