/* This is an asset derived from the abstract State SO. 
 * This file gives the ability to specify unique attributes as well as set its own Create asset menu entry*/

// This state represents the GameOver state, different than quit state, this state has an associated scene and UI for 
// returning to main menu or quitting (going to quit state)
using SM;
using UnityEngine;

namespace SO.States.GameStates
{
    [CreateAssetMenu(fileName = "GameOverState", menuName = "States/Game Over State")]
    public class GameOverState : State
    {
        #region Class Methods
        public override void OnEnter() 
        {
            if (Application.isPlaying)
            {
                //LoadAssociatedSceneAsync();
            }
            else if (Application.isEditor)
            {
               // OpenAssociatedSceneInEditor();
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