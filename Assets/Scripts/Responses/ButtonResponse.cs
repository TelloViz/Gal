/* This file is a button click response method wrapped in an SO.
 The purpose is to inject via the inspector, into any listener that needs to access this sort of response
I have many duplicates of this type of thing and need to consolodate to a single StateResponse So*/

// TODO: Unify response SO types under a single umbrella
using SM;
using UnityEngine;

namespace Responses
{
    [CreateAssetMenu(fileName = "ButtonResponse", menuName = "Button Response")]
    public class ButtonResponse : ScriptableObject
    {
        [SerializeField] private AppManager appManager;
        [SerializeField] private State responseState;

        public State ResponseState { get => responseState; set => responseState = value; }
        public AppManager AppManager { get => appManager; set => appManager = value; }

        public void Respond()
        {
            if (AppManager.AppStateMachine.ContainsState(ResponseState))
            {
                AppManager.AppStateMachine.ChangeState(ResponseState);
            }
        }
    }
}