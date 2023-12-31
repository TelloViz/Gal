//using UnityEngine;

//public abstract class HeroUnitBase : UnitBase {
//    private bool _canMove;

//    private void Awake() => GALGameManager.OnBeforeStateChanged += OnStateChanged;

//    private void OnDestroy() => GALGameManager.OnBeforeStateChanged += OnStateChanged;

//    private void OnStateChanged(eGameState newState) {
//        if (newState == eGameState.HeroTurn) _canMove = true;
//    }

//    private void OnMouseDown() {
//        // Only allow interactions when it's the hero turn
//        if (GALGameManager.Instance.State != eGameState.HeroTurn) return;

//        // Don't move if we've already moved
//        if (!_canMove) return;

//        // Show movement/attack options

//        // Eventually either deselect or ExecuteMove(). You could split ExecuteMove into multiple functions
//        // like Move() / Attack() / Dance()

//        Debug.Log("Unit clicked");
//    }

//    public virtual void ExecuteMove() {
//        // Override this to do some hero-specific logic, then call this base method to clean up the turn

//        _canMove = false;
//    }
//}