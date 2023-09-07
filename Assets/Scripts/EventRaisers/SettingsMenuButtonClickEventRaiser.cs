
using UnityEngine;

public class SettingsMenuButtonClickEventRaiser: MonoBehaviour
{
    [SerializeField] private AppManager appManager;
    [SerializeField] private GameEvent mainMenuButtonClickedEvent;

    public AppManager AppManager { get => appManager; set => appManager = value; }
    public GameEvent MainMenuButtonClickedEvent { get => mainMenuButtonClickedEvent; set => mainMenuButtonClickedEvent = value; }

    public void RaiseMainMenuButtonClickedEvent()
    {
        MainMenuButtonClickedEvent.Raise();
    }
}
