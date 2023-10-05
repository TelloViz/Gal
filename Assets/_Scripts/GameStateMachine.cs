
//using UnityEngine;
//using Vast.StateMachine;

//using GameState;
//using System;

//public class GameStateMachine : MonoBehaviour
//{
//    // Serialized StateMachine allows for changing states in editor at run-time
//    [SerializeField] private StateMachine stateMachine;
//    [SerializeField] private State2State[] state2States;

//    private InMainMenu inMainMenuState;
//    private InPlaying playingState;

//    public static event Action OnHandleStateChange;




//    private void OnDestroy()
//    {
//        stateMachine.OnStateChange -= HandleStateChange;
//    }

//    void Start()
//    {
//        stateMachine.OnStateChange += HandleStateChange;

//        inMainMenuState = new GameState.InMainMenu();
//        stateMachine.AddState(inMainMenuState);
//        stateMachine.ChangeState(inMainMenuState);

//        playingState = new GameState.InPlaying();
//        stateMachine.AddState(playingState);


//    }

//    private void HandleStateChange(State newState)
//    /// <summary>Hook into our underlying StateMachine field, This will get called on each state change</summary>
//    {

//        Debug.LogFormat("HandleStateChange({0}) called from GameStateMachine.stateMachine", newState);
//        OnHandleStateChange.Invoke();

//    }
//}
