/* This state is no longer used. It was the initial state the machine went to first always. 
 currently, the machine just goes straight into MainMenuState.*/
using UnityEngine;
using SM;

namespace SO.States.GameStates
{
    [CreateAssetMenu(fileName = "InitState", menuName = "States/Init State")]
    public class InitState : State
    {
        #region Class Methods
        public override void OnEnter() 
        {
            Debug.Log("InitState.OnEnter()");
            if(Application.isPlaying)
            {
               // LoadAssociatedSceneAsync();
            }
            else if(Application.isEditor)
            {
                //OpenAssociatedSceneInEditor();
            }


            
        }
        public override void OnExit() 
        {
           // DisableSceneObjects();
        }
        public override void Update() { }
        public override void FixedUpdate() { }
        #endregion
    }
}