// TODO I think this file can be broken up a little bit into simpler components
// this would allow for them to each be reused more simply elsewhere



using Cinemachine;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
#endif

namespace StarterAssets
{
	public class FirstPersonController : MonoBehaviour
	{

        [Header("Player")]
        [Tooltip("Rotation speed of the character")]
        public float RotationSpeed = 1.0f;
        [Tooltip("Acceleration and deceleration")]
        public float SpeedChangeRate = 10.0f;
		[SerializeField]
		private Transform playerInitLookTarget;
		[Space]
		[Header("Gun")]
		[Tooltip("The transform component of an impact FX prefab, instantiated upon impact")]
		[SerializeField]
		private Transform impactFX;
        [Tooltip("The force magnitude that the impact imparts on the hit object")]
        [SerializeField]
		private float hitStrength;
        [Tooltip("The audio clip that plays upon impact")]
        [SerializeField]
		private AudioClip shootAudio;
        [Tooltip("The audio system that plays the impact sound")]
        [SerializeField]
		private AudioSystem audioSystem;
        [Space]
        [Header("Cinemachine")]
        [Tooltip("The virtual camera set to follow the player")]
        [SerializeField]
        private CinemachineVirtualCamera playerVCam;
        [Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
		public GameObject CinemachineCameraTarget;
		[Tooltip("How far in degrees can you move the camera up")]
		public float TopClamp = 90.0f;
		[Tooltip("How far in degrees can you move the camera down")]
		public float BottomClamp = -90.0f;
        [Tooltip("How far in degrees can you move the camera up")]
        public float LeftClamp = 90.0f;
        [Tooltip("How far in degrees can you move the camera down")]
        public float RightClamp = -90.0f;

		//[SerializeField]
		//private LayerMask layerMask = new LayerMask();

		[SerializeField]
		private LayerMask aimColliderMask = new LayerMask();

		[SerializeField]
		private PlayerControls _input;

        private Transform transformPos = null;

        // cinemachine
        private float _cinemachineTargetPitch;
        private float _cinemachineTargetYaw;	

	
		#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
			[SerializeField] private PlayerInput _playerInput;
		#endif
		
		private const float _threshold = 0.01f;

		private bool IsCurrentDeviceMouse
		{
			get
			{
				#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
				return _playerInput.currentControlScheme == "KeyboardMouse";
				#else
				return false;
				#endif
			}
		}
		private void Start()
		{
			playerVCam.transform.LookAt(playerInitLookTarget.transform.position);
		}

		public void OnLook(CallbackContext context)
		{
			if (context.performed) CameraRotation(context.ReadValue<Vector2>());
		}

        private void CameraRotation(Vector2 lookVec)
        {
            // if there is an input
            if (lookVec.sqrMagnitude >= _threshold)
            {
                // Don't multiply mouse input by Time.deltaTime
                float deltaTimeMultiplier = IsCurrentDeviceMouse ? 1.0f : Time.deltaTime;

                // Update pitch and yaw with input
                _cinemachineTargetPitch += lookVec.y * RotationSpeed * deltaTimeMultiplier;
                _cinemachineTargetYaw += lookVec.x * RotationSpeed * deltaTimeMultiplier;

                // Clamp both pitch and yaw rotations
                _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);
                _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, LeftClamp, RightClamp);

                // Update Cinemachine camera target pitch and yaw
                CinemachineCameraTarget.transform.localRotation = Quaternion.Euler(_cinemachineTargetPitch, _cinemachineTargetYaw, 0.0f);

                // Rotate the player left and right
                //transform.Rotate(Vector3.up * _input.look.x * RotationSpeed * deltaTimeMultiplier);
            }
        }

		public void onShoot(CallbackContext context)
		{
			if (context.performed == true)
			{
              //  audioSystem.PlaySound(shootAudio);

                transformPos = null;
                Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
                Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);

                if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderMask))
                {
					transformPos = raycastHit.transform;
                    Shoot(raycastHit);

                }
                
			}
		}

		private void Shoot(RaycastHit raycastHit)
		{
            //Vector3 pos = InputManager.Instance.getMouseWorldPoint(layerMask);
            
            if (transformPos != null)
            {
				if(transformPos.GetComponent<BulletTarget>() != null) // TODO make this use the same aimCollider mask instead of a GetComponent call
                {
					// TODO apply force to target in reverse direction to shot point
					Rigidbody hitRB = transformPos.gameObject.GetComponent<Rigidbody>();
				//
				//	Debug.Log(hitRB.gameObject.name);
					
					if (hitRB != null) 
					
						hitRB.AddForceAtPosition(-raycastHit.normal.normalized * hitStrength, raycastHit.point, ForceMode.Impulse );
					
					else 
						
						Debug.Log("Force not applied");


                    Instantiate(impactFX, raycastHit.point, Quaternion.identity); 
					Debug.Log("impactFX instantiated");
                }
            }
                    
        }


		private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
		{
			if (lfAngle < -360f) lfAngle += 360f;
			if (lfAngle > 360f) lfAngle -= 360f;
			return Mathf.Clamp(lfAngle, lfMin, lfMax);
		}		
	}
}