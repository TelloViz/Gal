//using System;
//using UnityEngine;

///// <summary>
///// Nice, easy to understand enum-based game manager. For larger more complex games, look into
///// state machines. But this will serve just fine for most games.
///// </summary>
//public class ExampleGameManager : Singleton<ExampleGameManager> {
//    public static event Action<eGameState> OnBeforeStateChanged;
//    public static event Action<eGameState> OnAfterStateChanged;

//    public eGameState State { get; private set; }

//    // Kick game off with the first state
//    void Start() => ChangeState(eGameState.Starting);

//    public void ChangeState(eGameState newState) {
//        OnBeforeStateChanged?.Invoke(newState);

//        State = newState;
//        switch(newState) {
//            case eGameState.Starting:
//                HandleStarting();
//                break;
//            case eGameState.SpawningHeroes:
//                HandleSpawningHeroes();
//                break;
//            case eGameState.SpawningEnemies:
//                HandleSpawningEnemies();
//                break;
//            case eGameState.HeroTurn:
//                HandleHeroTurn();
//                break;
//            case eGameState.EnemyTurn:
//                break;
//            case eGameState.Win:
//                break;
//            case eGameState.Lose:
//                break;
//            default:
//                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
//        }

//        OnAfterStateChanged?.Invoke(newState);

//        Debug.Log($"New State: {newState}");
//    }

//    private void HandleStarting() {
//        // Do some start setup, could be environment, cinematics, etc.

//        // Eventually call ChangeState again with your next state.

//        ChangeState(eGameState.SpawningHeroes);
//    }

//    private void HandleSpawningHeroes() {
//        // ExampleUnitManager.Instance.SpawnHeroes();

//        ChangeState(eGameState.SpawningEnemies);
//    }

//    private void HandleSpawningEnemies()
//    {
//        // ExampleUnitManager.Instance.SpawnEnemies();

//        // ChangeState(eGameState.HeroTurn);
//    }

//    private void HandleHeroTurn() {
//        // if you're making a turn based game, this could show the turn menu, highlight available units etc

//        // Keep track of how many units need to make a move, once they've all finished, change the state. This could
//        // be monitored in the unit manager or the units themselves.
//    }



//}

///// <summary>
///// This is obviously an example and I have no idea what kind of game you're making.
///// Yoou can use a similar manager for controlling your menu states or dynamic-cinematics, etc.
///// </summary>
//[Serializable]
//public enum eGameState {
//    Starting = 0,
//    SpawningHeroes = 1,
//    SpawningEnemies = 2,
//    HeroTurn = 3,
//    EnemyTurn = 4,
//    Win = 5,
//    Lose = 6
//}