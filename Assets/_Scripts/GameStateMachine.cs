
using UnityEngine;
using Vast.StateMachine;

using GameState;

public class GameStateMachine : MonoBehaviour
{
    // Serialized StateMachine allows for changing states in editor at run-time
    [SerializeField] private StateMachine stateMachine;

    private GameState.InMainMenu inMainMenuState;
    private GameState.Playing playingState;
    //private GameState.InPauseMenu inPauseMenuState;

    [SerializeField] private GameObject inMainMenuController;
    [SerializeField] private GameObject PlayingController;
    //[SerializeField] private GameObject inPauseMenuController;

    // Note to self: Awake called before Start(), even if script it disabled.
    private void Awake()
    {

    }

    private void OnDestroy()
    {
        stateMachine.OnStateChange -= HandleStateChange;
    }

    void Start()
    {
        stateMachine.OnStateChange += HandleStateChange;

        inMainMenuState = new GameState.InMainMenu();
        stateMachine.AddState(inMainMenuState);
        stateMachine.ChangeState(inMainMenuState);

        playingState = new GameState.Playing();
        stateMachine.AddState(playingState);


    }

    private void HandleStateChange(State newState)
    /// <summary>Hook into our underlying StateMachine field, This will get called on each state change</summary>
    {

        Debug.Log(this.name + " says, the state is now " + newState.Name);

        // TODO: Handle state changes, deligate to individual state handling objects maybe
        // TODO: Determine flow of control for this

        if(newState.Name == "InMainMenu")
        {
            Debug.Log("GameStateMachine handling InMainMenu state");
            inMainMenuController.SetActive(true);
            PlayingController.SetActive(false);
            //inPauseMenuController.SetActive(false);
        }
        else if(newState.Name == "Playing")
        {
            Debug.Log("GameStateMachine handling Playing state");
            inMainMenuController.SetActive(false);
            PlayingController.SetActive(true);
            //inPauseMenuController.SetActive(false);
        }
        else if(newState.Name == "InPauseMenu")
        {
            Debug.Log("GameStateMachine handling InPauseMenu state");
            inMainMenuController.SetActive(false);
            PlayingController.SetActive(false);
            //inPauseMenuController.SetActive(true);
        }

    }
}
