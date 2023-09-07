/* This is an asset derived from the abstract State SO. 
 * This file gives the ability to specify unique attributes as well as set its own Create asset menu entry*/

// This state represents the last state the machine enters/exits. This is the Quit State.

using UnityEngine;
using SM.StateMachine;
using SM;

namespace SO.States.GameStates
{
    [CreateAssetMenu(fileName = "QuitState", menuName = "States/Quit State")]
    public class QuitState : State
    {
        #region Class Methods
        public override void OnEnter() 
        {
            Application.Quit();
        }
        public override void OnExit() { }
        public override void Update() { }
        public override void FixedUpdate() { }
        #endregion
    }
}