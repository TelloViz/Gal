using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "StringSO", menuName = "SO/StringSO", order = 1)]
    public class StringSO : ScriptableObject
    {
        [SerializeField] private string value;

        public string Value { get => value;}
    }
}