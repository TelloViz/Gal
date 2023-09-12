using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Aim : MonoBehaviour
{
    [SerializeField]
    private InputManager inputManager;

    [SerializeField]
    private Transform upperArm;

    //values that will be set in the Inspector
    public Transform Target;
    public float RotationSpeed;

    //values for internal use
    private Quaternion _lookRotation;
    private Vector3 _direction;

    // Update is called once per frame
    void Update()
    {
        //upperArm.LookAt(inputManager.getMouseWorldPoint().normalized);

        //upperArm.LookAt(Target);
        //upperArm.LookAt(inputManager.getMouseWorldPoint(), new Vector3(-1, 0, 0).normalized);
    }

    

    public void HandleLook(InputAction.CallbackContext context)
    {
        Vector2 lookPos = context.ReadValue<Vector2>();


    }
}
