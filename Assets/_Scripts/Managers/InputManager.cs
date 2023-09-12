using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : Singleton<InputManager>
{
    private PlayerControls playerControls;

    [SerializeField]
    private Transform debugTransform;

    [SerializeField] private bool showDebugTarget = false;

    [SerializeField]
    private LayerMask aimColliderLayerMask = new();

    private Vector3 oldDebugTransformPosition = Vector3.negativeInfinity;

    private PlayerControls GetPlayerControls()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
            playerControls.Enable();
            //playerControls.RailGunner.Enable();
        }
        return playerControls;
    }

    private void OnEnable()
    {
        playerControls = GetPlayerControls();
        Cursor.visible = false;
    }

    private void Update()
    {
        if (showDebugTarget)
        {
            Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
            {
                debugTransform.position = raycastHit.point;
            }
        }

       // Debug.Log(getMouseWorldPoint());

    }

    public Vector3 getMouseWorldPoint()
    {
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            return raycastHit.point;
        }

        return Vector3.zero;

        
    }

    private void OnDisable()
    {
        playerControls.Disable();
        Cursor.visible = true;
    }
    public Vector2 GetMouseDelta()
    {
        return playerControls.RailGunner.Look.ReadValue<Vector2>();
    }
}
