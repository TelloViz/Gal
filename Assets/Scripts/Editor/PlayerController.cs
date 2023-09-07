/* This file is currently unused. */

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameEvent pausePressedGameEvent;

    
    public void PrintMessage()
    {
        Debug.Log("PlayerController.PrintMessage()");
    }

    public void RaisePausePressedEvent()
    {
        pausePressedGameEvent.Raise();
    }
}
