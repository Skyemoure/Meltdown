using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CambiarCamara : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;

    private CinemachineVirtualCamera virtualCamera;
    private InputAction aimAction;

    [SerializeField]
    private Canvas canvas;
    // Start is called before the first frame update
    private void Awake()
    {
        
        canvas.enabled = false;
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        aimAction = playerInput.actions["Aim"];
    }

    // Update is called once per frame
    private void OnEnable()
    {
        aimAction.performed += _ => StartAim();
        aimAction.canceled += _ => CancelAim();
    }

    private void OnDisable()
    {
        aimAction.performed -= _ => StartAim();
        aimAction.canceled -= _ => CancelAim();
    }

    private void StartAim()
    {
        virtualCamera.Priority += 10;
        canvas.enabled = true;
    }

    private void CancelAim()
    {
        virtualCamera.Priority -= 10;
        canvas.enabled = false;
    }
}
