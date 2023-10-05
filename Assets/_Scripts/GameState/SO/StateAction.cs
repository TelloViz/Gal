using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="StateAction", menuName ="SO/State Actions/StateActionBase", order = 0)]
public class StateAction : ScriptableObject {}





[CreateAssetMenu(fileName = "MainMenuStartAction", menuName = "SO/State Actions/MainMenuStartAction", order = 0)]
public class MainMenuStartAction : StateAction { }

[CreateAssetMenu(fileName = "MainMenuQuitAction", menuName = "SO/State Actions/MainMenuQuitAction", order = 0)]
public class MainMenuQuitAction : StateAction { }