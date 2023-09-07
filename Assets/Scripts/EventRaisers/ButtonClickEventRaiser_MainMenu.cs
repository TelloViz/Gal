
using UnityEngine;

public class ButtonClickEventRaiser_MainMenu : MonoBehaviour
{
    [SerializeField] AppManager appManager;
    [SerializeField] GameEvent startButtonClicked;
    [SerializeField] GameEvent settingsButtonClicked;
    [SerializeField] GameEvent quitButtonClicked;

    public AppManager AppManager { get => appManager; set => appManager = value; }

    public void RaiseStartButtonClickedEvent()
    {
        startButtonClicked.Raise();
    }

    public void RaiseSettingsMenuButtonClickedEvent()
    {
        settingsButtonClicked.Raise();
    }
    public void RaiseQuitButtonClickedEvent()
    {
        quitButtonClicked.Raise();
    }
}
