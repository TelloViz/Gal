using UnityEngine;
using UnityEngine.InputSystem;

//[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private LayerMask aimColliderLayerMask = new LayerMask();

    [SerializeField]
    private InputManager inputManager;
    [SerializeField]
    private InputActionAsset inputAsset;

    //private CharacterController controller;
    
    
    private Vector3 playerVelocity;
    //private Transform cameraTransform;

    [SerializeField]
    private Transform debugTransform;


    private void Start()
    {
        //cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if(Physics.Raycast(ray,out RaycastHit raycastHit,999f, aimColliderLayerMask))
        {
            //debugTransform.position = raycastHit.point;
            
        }
    }
}
