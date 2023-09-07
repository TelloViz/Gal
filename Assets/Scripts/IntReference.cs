

using SO.Variables;
using System;
using UnityEngine;

[Serializable]
public class IntReference
{
    [SerializeField] private bool useConstant = true;
    [SerializeField] private int constantValue;
    [SerializeField] private IntVariable variable;

    public int Value
    {
        get { return UseConstant ? ConstantValue : Variable.Value; }
    }

    public bool UseConstant { get => useConstant; set => useConstant = value; }
    public int ConstantValue { get => constantValue; set => constantValue = value; }
    public IntVariable Variable { get => variable; set => variable = value; }
}