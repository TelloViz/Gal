using SO.States.GameStates;
using System.Collections.Generic;
using UnityEngine;
using SM.StateMachine;
using SM;

[CreateAssetMenu(fileName = "AppManager", menuName = "Managers/AppManager")]
public class AppManager : ScriptableObject
{
    [SerializeField] private StateMachine appStateMachine;
    [SerializeField] private State initialState;
    [SerializeField] private State[] registeredStates;

    public StateMachine AppStateMachine { get => appStateMachine; set => appStateMachine = value; }
    public State InitialState { get => initialState; set => initialState = value; }


    private void OnEnable()
    {
        //foreach (var state in registeredStates)
        //{
        //    if(!AppStateMachine.ContainsState(state))
        //    {
        //        AppStateMachine.AddStates(registeredStates);
        //    }
        //}
        
        //if(AppStateMachine.ActiveState != initialState)
        //{
        //    AppStateMachine.ChangeState(initialState);
        //}
    }
}


// Design notes:

/* 
 
    States:         
+--------------+
+   MainMenu   + 
+   Playing    +
+   Pausing    +
+   GameOver   +
+   Quit       +
+--------------+

                          Origin:
Transistions:           Main Menu     Playing    Pausing     Game Over    Quit
+------------------+---------------+---------------------+-------------+---------+
|   Click Start    |    Playing    |  ---      |    ---    |    ---    |   !!!   |
|   Click Quit     |    Quit       |  ---      |    ---    |    ---    |   !!!   |
|   Select Quit    |    ---        |  ---      |   Quit    |   Quit    |   !!!   |
|   Select Menu    |    ---        |  ---      | Main Menu | Main Menu |   !!!   |
|   Game Lose      |    ---        | Game Over |    ---    |    ---    |   !!!   |
|   Press Pause    |    ---        | Pausing   |    ---    |    ---    |   !!!   |
|   Select Resume  |    ---        |  ---      |  Playing  |    ---    |   !!!   |
+------------------+-------------------------------------------------------------+
 
--- == Not Valid (Also could be represented as self loops because these inputs wouldn't cause a state change.
 !!! == Accept State

 
 
 */