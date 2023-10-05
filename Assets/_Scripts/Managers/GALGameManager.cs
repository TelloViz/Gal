using GameState;
using System;
using UnityEngine;
using Vast.StateMachine;

public class GALGameManager : Singleton<GALGameManager>
{

    [Tooltip("The FSM governing the flow of the application")]
    [SerializeField] private Vast.StateMachine.StateMachine gameStateMachine;
    


    //public static event Action OnStateChangeBroadcast;
    public static Action<State> OnStateChangeBroadcast { get; set; }




    private void Start()
    {
        gameStateMachine.AddState(new InStarting());
        gameStateMachine.AddState(new InMainMenu());
        gameStateMachine.AddState(new InPlaying());
        gameStateMachine.AddState(new InPauseMenu());
        gameStateMachine.AddState(new InQuitting());
        gameStateMachine.AddState(new InScore());

        gameStateMachine.OnStateChange += HandleStateChange;
    }


    private void HandleStateChange(State newState)
    /// <summary>Hook into our underlying StateMachine field, This will get called on each state change</summary>
    {

        Debug.LogFormat("HandleStateChange({0}) called from GALGameManager.gameStateMachine", newState);
        OnStateChangeBroadcast?.Invoke(newState);
        //if (newState.Name == "InStarting")
        //{
        //    OnStartingState();
        //}
        //else if (newState.Name == "InMainMenu")
        //{
        //    OnMainMenuState();
        //}
        //else if (newState.Name == "InPlaying")
        //{
        //    OnPlayingState();
        //}
        //else if (newState.Name == "InPauseMenu")
        //{
        //    OnPausingState();
        //}
        //else if (newState.Name == "InScore")
        //{
        //    OnScoreState();
        //}
        //else if (newState.Name == "InQuitting")
        //{
        //    OnQuittingState();
        //}
        //else
        //{
        //    Debug.Log("Unrecognized State.Name");
        //}



}

// Param:  s2s : State2State -- A ScriptableObject holding the contextual information pertaining to the state transition occuring
private void OnStartingState() 
    {
        // Register this Function to be called when the state machine has entered "StartingState"
        // This function will then acivate the relevant Game Objects and/or Components
        // In some order relevant, to effectively initialize and set the state into operation

        //OnStartingStateCallback.Invoke();
    }

    // Param:  s2s : State2State -- A ScriptableObject holding the contextual information pertaining to the state transition occuring
    private void OnMainMenuState() {
        // Register this Function to be called when the state machine has entered "MainMenuState"
        // This function will then acivate the relevant Game Objects and/or Components
        // In some order relevant, to effectively initialize and set the state into operation

        //OnMainMenuStateCallback.Invoke();
    }

    // Param:  s2s : State2State -- A ScriptableObject holding the contextual information pertaining to the state transition occuring
    private void OnPlayingState()
    {
        // Register this Function to be called when the state machine has entered "Playing"
        // This function will then acivate the relevant Game Objects and/or Components
        // In some order relevant, to effectively initialize and set the state into operation

        //OnPlayingStateCallback.Invoke();

    }

    // Param:  s2s : State2State -- A ScriptableObject holding the contextual information pertaining to the state transition occuring
    private void OnPausingState()
    {
        // Register this Function to be called when the state machine has entered "Pausing"
        // This function will then acivate the relevant Game Objects and/or Components
        // In some order relevant, to effectively initialize and set the state into operation

        //OnPausingStateCallback.Invoke();

    }

    private void OnQuittingState() 
    {
        // Register this Function to be called when the state machine has entered "QuittingState"
        // This function will then acivate the relevant Game Objects and/or Components
        // In some order relevant, to effectively initialize and set the state into operation

        //OnQuittingStateCallback.Invoke();

    }

    // Param:  s2s : State2State -- A ScriptableObject holding the contextual information pertaining to the state transition occuring
    private void OnScoreState() 
    {
        // Register this Function to be called when the state machine has entered "ScoreState"
        // This function will then acivate the relevant Game Objects and/or Components
        // In some order relevant, to effectively initialize and set the state into operation

        //OnScoreStateCallback.Invoke();

    }


    }








    // TODO get rid of the following code when safe to do so


    /// <summary>
    /// This is obviously an example and I have no idea what kind of game you're making.
    /// Yoou can use a similar manager for controlling your menu states or dynamic-cinematics, etc.
    /// </summary>
    [Serializable]
public enum eGameState
{
     InitApp = 0,
     InitMainMenu = 1,
     MainMenu=2,
     InitPrePlay=3,
     PrePlay=4,
     InitPlay=5,
     Play=6,
     InitScore=7,
     Score=8,
     InitContinue=9,
     Continue=10
}