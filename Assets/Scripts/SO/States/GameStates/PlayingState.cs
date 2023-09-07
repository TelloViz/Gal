/* This is an asset derived from the abstract State SO. 
 * This file gives the ability to specify unique attributes as well as set its own Create asset menu entry*/

// This state represents the regular Playing mode of the game.

using SM;
using UnityEngine;

namespace SO.States.GameStates
{
    [CreateAssetMenu(fileName = "PlayingState", menuName = "States/Playing State")]
    public class PlayingState : State
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
                //OpenAssociatedSceneInEditor();
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