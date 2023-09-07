using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Button", menuName = "Controls/Button")]
public class MenuButton : ScriptableObject
{
    [SerializeField]
    private Button buttonControl;

    public Button ButtonControl { get => buttonControl; set => buttonControl = value; }

}
