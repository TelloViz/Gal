
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainMenuManager : Singleton<MainMenuManager>
{ 
    //private PlayerControls playerControls;

    public static event Action MainMenuManagerStartClicked;
    public static event Action MainMenuManagerQuitClicked;

    private void OnEnable()
    {
        //playerControls.UI.Enable();
        MainMenuScreen.StartButtonClicked += MainMenuScreenStartClicked;
        MainMenuScreen.QuitButtonClicked += MainMenuScreenQuitClicked;
    }

    private void OnDisable()
    {
        //playerControls.UI.Disable();
        MainMenuScreen.StartButtonClicked -= MainMenuScreenStartClicked;
        MainMenuScreen.QuitButtonClicked -= MainMenuScreenQuitClicked;
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
