using UnityEngine;

namespace SO.Variables
{
    [CreateAssetMenu(fileName = "StringVariable", menuName = "Vars/String")]
    public class StringVariable : ScriptableObject
    {
        [SerializeField] private string value;

        public string Value { get => value; set => this.value = value; }
    }
}