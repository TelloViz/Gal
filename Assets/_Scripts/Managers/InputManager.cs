using Cinemachine;
using Cinemachine.Utility;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : Singleton<InputManager>
{
    private PlayerControls playerControls;

    [SerializeField]
    private Transform cursorModel;

    [SerializeField]
    private Camera uiCam;

    [SerializeField]
    private CinemachineVirtualCamera uiVCam;

    [SerializeField]
    private Camera playerCam;
    
    [SerializeField]
    private CinemachineVirtualCamera playerVCam;

    // TODO create logic that sets currentCam = uiCam || playerCam 
    // Depending on what state we are in
    private Camera currentCam;


    [SerializeField] private bool showDebugTarget = false;

    [SerializeField]
    private LayerMask aimColliderLayerMask = new();


    // TODO This is temporary to test the changing to MainMenu State with the current terrible state setup

    //[SerializeField]
    //GALGameManager gameManager;


    private PlayerControls GetPlayerControls()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
            playerControls.Enable();
        }
        return playerControls;
    }

    private void OnEnable()
    {
        playerControls = GetPlayerControls();
        //Cursor.visible = false;
    }

    private void Update()
    {
        if (showDebugTarget)
        {
            Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Ray ray = playerCam.ScreenPointToRay(screenCenterPoint);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
            {
                cursorModel.position = raycastHit.point;
            }
        }

       // Debug.Log(getMouseWorldPoint());

    }

    public Vector3 getMouseWorldPoint()
    {
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = playerCam.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            return raycastHit.point;
        }

        return Vector3.negativeInfinity;

        
    }

    public Vector3 getMouseWorldPoint(LayerMask aimColliderLayerMask)
    {
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = playerCam.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            Debug.Log("Bang!");

            return raycastHit.point;
        }

        return Vector3.negativeInfinity;
		
    }

    private void OnDisable()
    {
        playerControls.Disable();

        Cursor.visible = true;
    }


}
