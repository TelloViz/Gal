namespace SM
{
    public interface IStateMachine
    {
        State AddState(State stateToAdd);
        State[] AddStates(params State[] statesToAdd);
        void RemoveState(State stateToRemove);
        void RemoveState(string stateNameToRemove);
        void RemoveStates(params State[] statesToRemove);
        void RemoveStates(params string[] stateNamesToRemove);
        void ChangeState(State toState);
        void ChangeState(string toStateName);
        void UpdateActiveState();
        void FixedUpdateActiveState();
        bool ContainsState(State state);
        bool ContainsState(string stateName);
        bool ContainsState(string stateName, out State foundState);
    }
}