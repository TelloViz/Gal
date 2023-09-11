using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private LayerMask aimColliderLayerMask = new LayerMask();

    [SerializeField]
    private InputManager inputManager;
    [SerializeField]
    private InputActionAsset inputAsset;
    [SerializeField]
    private CharacterController controller;
    
    
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform cameraTransform;

    private Transform debugTransform;


    private void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if(Physics.Raycast(ray,out RaycastHit raycastHit,999f, aimColliderLayerMask))
        {
            Debug.Log(debugTransform.position = raycastHit.point);
        }
    }
}
