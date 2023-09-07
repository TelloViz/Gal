using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using SM.StateMachine;
using SM;

public class StateMachineInitializer : MonoBehaviour
{

    [SerializeField] private AppManager appManager;
    [SerializeField] private State associatedState;
    [SerializeField] private List<State> statesToRegister;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("StateMachineInitializer.Start()");

        // Right now there is no initialization to be done
        // other than transitioning to the actual first state...
        //if (associatedState.ReachableStates.Any())
        //{
        //    Debug.Log("There is a reachable state to transition to from InitState \n State Reachable: " + associatedState.ReachableStates.First<State>().ToString());

        //    appManager.AppStateMachine.ChangeState(associatedState.ReachableStates.First<State>());
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
