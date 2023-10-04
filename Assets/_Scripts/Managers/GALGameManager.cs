using System;
using UnityEngine;

public class GALGameManager : Singleton<GALGameManager>
{

    [Tooltip("The FSM governing the flow of the application")]
    [SerializeField] private GameStateMachine gameStateMachine;    

    //[Header("Input Manager")]
    [Tooltip("The Input Manager oversees any input systems")]
    [SerializeField] private GameObject inputMgrGO;
    private InputManager _inputMgr;

    [Tooltip("The Main Menu Manager oversees any Main Menu systems")]
    [SerializeField] private GameObject mainMenuMgrGO;
    private MainMenuManager _mainMenuMgr;

    private void OnEnable()
        {
            _inputMgr = inputMgrGO.GetComponent<InputManager>();
            if (_inputMgr == null)
            {
                Debug.Log("No InputManager script found on Input Manager Game Object");
            }

            _mainMenuMgr = mainMenuMgrGO.GetComponent<MainMenuManager>();
        if(_mainMenuMgr == null)
        {
            Debug.Log("No MainMenuManager script found on Main Menu Manager Game Object");
        }

        MainMenuManager.MainMenuManagerStartClicked += StartApplication;
            MainMenuManager.MainMenuManagerQuitClicked += QuitApplication;
        }

    private void OnDisable()
        {
            MainMenuManager.MainMenuManagerStartClicked -= StartApplication;
            MainMenuManager.MainMenuManagerQuitClicked -= QuitApplication;
        }

    private void StartApplication()
        {
            // This function will trigger the transition to the next game state after Main Menu State
            Debug.Log("GalGameManager says: StartApplication() was called.");
        }
    
    private void QuitApplication()
        {
            Debug.Log("GalGameManager says: Goodbye!");
            Helpers.Quit();
        }
}

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