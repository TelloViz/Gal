 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SO.Variables
{

    [CreateAssetMenu(fileName = "FloatVariable", menuName = "Vars/Float")]
    public class FloatVariable : ScriptableObject
    {
        private float value;

        public float Value { get => value; set => this.value = value; }
    }
}