using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vast.StateMachine;

public class InStarting : State
{
    private const string DEFAULT_NAME = "InStarting";

    public InStarting(string name = DEFAULT_NAME)
    {
        Name = name;
        UnityEngine.Debug.Log(name + " state created...");
    }

    public override void OnEnter() { Debug.Log("Entered " + this.Name + " state..."); }

    public override void OnExit() { Debug.Log("Exited " + this.Name + " state..."); }
    public override void FixedUpdate()
    {
    }
    public override void Update()
    {
    }
}
