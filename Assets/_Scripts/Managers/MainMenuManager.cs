
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.UIElements;
using Vast.StateMachine;

[RequireComponent(typeof(MainMenuScreen), typeof(UIDocument), typeof(InputSystemUIInputModule))]
public class MainMenuManager : Singleton<MainMenuManager>
{
    private MainMenuScreen menuScreen;
    private UIDocument uiDocument;
    private InputSystemUIInputModule uiInput;
    private EventSystem eventSys;


    public static event Action MainMenuManagerStartClicked;
    public static event Action MainMenuManagerQuitClicked;

    private void OnEnable()
    {
        uiDocument = GetComponent<UIDocument>();
        menuScreen = GetComponent<MainMenuScreen>();
        uiInput = GetComponent<InputSystemUIInputModule>();
        eventSys = GetComponent<EventSystem>();


        //playerControls.UI.Enable();
        MainMenuScreen.StartButtonClicked += MainMenuScreenStartClicked;
        MainMenuScreen.QuitButtonClicked += MainMenuScreenQuitClicked;

        GALGameManager.OnStateChangeBroadcast += ProcessStateChange;



    }

    private void OnDisable()
    {
        //playerControls.UI.Disable();
        MainMenuScreen.StartButtonClicked -= MainMenuScreenStartClicked;
        MainMenuScreen.QuitButtonClicked -= MainMenuScreenQuitClicked;
    }

    private void ProcessStateChange(State state)
    {
        Debug.LogFormat("MainMenuManager.ProcessStateChange({0})", state.Name);
        if (state.Name == "InMainMenu") ActivateMainMenu();
    }

    private void ActivateMainMenu()
    {
        Debug.Log("Activating Main Menu");
        uiDocument.enabled = true;
        menuScreen.enabled = true;
        uiInput.enabled = true;
        if (eventSys != null) eventSys.enabled = true;
    }

    public void MainMenuScreenStartClicked()
    {
       
        MainMenuManagerStartClicked?.Invoke();
    }
    public void MainMenuScreenQuitClicked()
    {
        MainMenuManagerQuitClicked?.Invoke();
    }
}
