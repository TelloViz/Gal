using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    private PlayerControls playerControls;

    private void Awake()
    {        
        base.Awake();
        playerControls = new PlayerControls();
        Cursor.visible= false;
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
    public Vector2 GetMouseDelta()
    {
        return playerControls.RailGunner.Look.ReadValue<Vector2>();
    }
}
