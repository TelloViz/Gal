using SO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State2State : ScriptableObject
{
    // Properties:

    // DepartState ID
    [SerializeField] private StringSO departStateID;
    // TransitionCondition ID(s)
    [SerializeField] private StringSO[] transitionConditionID;
    // ArriveState ID
    [SerializeField] private StringSO arriveStateID;

    public StringSO DepartStateID { get => departStateID; set => departStateID = value; }
    public StringSO[] TransitionConditionID { get => transitionConditionID; set => transitionConditionID = value; }
    public StringSO ArriveStateID { get => arriveStateID; set => arriveStateID = value; }


    // Upon Depart Do the following (signal only)
    // List of GameObjects to Deactivate (optional)
    // List of Components to Deactivate (optional)

    // Upon Arrival Do the Following (signal only)
    // List of GameObjects to Activate (optional)
    // List of Components to Activate (optional)
}
