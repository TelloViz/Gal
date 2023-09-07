
using UnityEngine;

public class ButtonClickEventRaiser_PausingMenu : MonoBehaviour
{
    [SerializeField] AppManager appManager;
    [SerializeField] GameEvent resumeButtonClicked;
    [SerializeField] GameEvent mainMenuButtonClicked;
    [SerializeField] GameEvent quitButtonClicked;

    public AppManager AppManager { get => appManager; set => appManager = value; }
    public GameEvent ResumeButtonClicked { get => resumeButtonClicked; set => resumeButtonClicked = value; }
    public GameEvent MainMenuButtonClicked { get => mainMenuButtonClicked; set => mainMenuButtonClicked = value; }
    public GameEvent QuitButtonClicked { get => quitButtonClicked; set => quitButtonClicked = value; }

    public void RaiseResumeButtonClickedEvent()
    {
        ResumeButtonClicked.Raise();
    }

    public void RaiseMainMenuButtonClickedEvent()
    {
        MainMenuButtonClicked.Raise();
    }
    public void RaiseQuitButtonClickedEvent()
    {
        QuitButtonClicked.Raise();
    }
}

