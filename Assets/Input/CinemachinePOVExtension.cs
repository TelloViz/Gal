using UnityEngine;
using Cinemachine;

public class CinemachinePOVExtension : CinemachineExtension
{

    [SerializeField]
    private float horizontalSpeed = 10f;
    [SerializeField]
    private float verticalSpeed = 10f;
    [SerializeField]
    private float clampAngleXPositive = 60;
    [SerializeField]
    private float clampAngleXNegative = 60f;
    [SerializeField]
    private float clampAngleYPositive = 45f;
    [SerializeField]
    private float clampAngleYNegative = 20f;

    private InputManager inputManager;
    private Vector3 startingRotation;

    protected override void Awake()
    {
        inputManager = InputManager.Instance;
        base.Awake();
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (Application.isPlaying)
        {
            if (vcam.Follow)
            {
                if (stage == CinemachineCore.Stage.Aim)
                {
                    if (startingRotation == null) startingRotation = transform.localRotation.eulerAngles;
                    Vector2 deltaInput = inputManager.GetMouseDelta();
                    startingRotation.x += deltaInput.x * verticalSpeed * Time.deltaTime;
                    startingRotation.y += deltaInput.y * horizontalSpeed * Time.deltaTime;
                    startingRotation.x = Mathf.Clamp(startingRotation.x, -clampAngleXNegative, clampAngleXPositive);
                    startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngleYNegative, clampAngleYPositive);
                    state.RawOrientation = Quaternion.Euler(-startingRotation.y, startingRotation.x, 0f);
                }
            }
        }


    }
}
