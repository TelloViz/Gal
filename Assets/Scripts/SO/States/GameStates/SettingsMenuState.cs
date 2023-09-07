/* This is an asset derived from the abstract State SO. 
 * This file gives the ability to specify unique attributes as well as set its own Create asset menu entry*/

// This state represents settings menu.

using UnityEngine;
using SM;

namespace SO.States.GameStates
{
    [CreateAssetMenu(fileName = "SettingsMenuState", menuName = "States/Settings Menu State")]
    public class SettingsMenuState : State
    {
        #region Class Methods
        public override void OnEnter()
        {
            if (Application.isPlaying)
            {
              //  LoadAssociatedSceneAsync();
            }
            else if (Application.isEditor)
            {
              //  OpenAssociatedSceneInEditor();
            }
        }
        public override void OnExit()
        {
            //DisableSceneObjects();
        }
        public override void Update() { }
        public override void FixedUpdate() { }
        #endregion
    }
}