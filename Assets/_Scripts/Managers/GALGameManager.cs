using System;
using UnityEngine;

/// <summary>
/// Nice, easy to understand enum-based game manager. For larger more complex games, look into
/// state machines. But this will serve just fine for most games.
/// </summary>
public class GALGameManager : Singleton<GALGameManager>
{
    public static event Action<GameState> OnBeforeStateChanged;
    public static event Action<GameState> OnAfterStateChanged;

    public GameState State { get; private set; }

    // Kick game off with the first state
    void Start() => ChangeState(GameState.Starting);

    public void ChangeState(GameState newState)
    {
        OnBeforeStateChanged?.Invoke(newState);

        State = newState;
        switch (newState)
        {
            case GameState.Starting:
                HandleStarting();
                break;
            case GameState.MainMenu:
                HandleMainMenu();
                break;
            case GameState.SpawningHeroes:
                HandleSpawningHeroes();
                break;
            case GameState.SpawningEnemies:
                HandleSpawningEnemies();
                break;
            case GameState.HeroTurn:
                HandleHeroTurn();
                break;
            case GameState.EnemyTurn:
                break;
            case GameState.Win:
                break;
            case GameState.Lose:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnAfterStateChanged?.Invoke(newState);

        Debug.Log($"New State: {newState}");
    }

    private void HandleStarting()
    {
        // Do some start setup, could be environment, cinematics, etc.

        // Eventually call ChangeState again with your next state.
       // ChangeState(GameState.MainMenu);
    }

    private void HandleMainMenu()
    {
        // State to idle in while we are in the main menu...





        ChangeState(GameState.SpawningHeroes);
    }

    private void HandleSpawningHeroes()
    {
       // ExampleUnitManager.Instance.SpawnHeroes();

        ChangeState(GameState.SpawningEnemies);
    }

    private void HandleSpawningEnemies()
    {
        //ExampleUnitManager.Instance.SpawnEnemies();

        ChangeState(GameState.HeroTurn);
    }

    private void HandleHeroTurn()
    {
        // if you're making a turn based game, this could show the turn menu, highlight available units etc

        // Keep track of how many units need to make a move, once they've all finished, change the state. This could
        // be monitored in the unit manager or the units themselves.
    }



}

/// <summary>
/// This is obviously an example and I have no idea what kind of game you're making.
/// Yoou can use a similar manager for controlling your menu states or dynamic-cinematics, etc.
/// </summary>
[Serializable]
public enum GameState
{
    Starting = 0,
    MainMenu = 1,
    SpawningHeroes = 2,
    SpawningEnemies = 3,
    HeroTurn = 4,
    EnemyTurn = 5,
    Win = 6,
    Lose = 7
}