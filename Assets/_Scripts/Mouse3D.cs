using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse3D : MonoBehaviour
{
    public static Mouse3D Instance { get; private set;}



    [SerializeField]
    private Transform debugTransform;


    private void Awake()
    {
        Instance = this;
    }

    //private void Update()
    //{
    //    Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
    //    Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
    //    if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, mouseColliderLayerMask))
    //    {
    //        debugTransform.position = raycastHit.point;
    //    }
    //}


}
