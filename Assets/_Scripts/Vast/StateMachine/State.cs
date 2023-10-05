using System;

namespace Vast.StateMachine {
    [Serializable]
    public abstract class State {
        private string name = String.Empty;

        #region Properties
        public string Name {
            get { return this.name; }
            protected set { this.name = value; }
        }
        #endregion


        // These are useful if the logic for each state resides in the derived state
        // itself. However, if the logic resides in external game objects, and the state
        // simply acts as a sort of flag for other objects to await signal, then perhaps
        // these aren't as useful?
        #region Class Methods
        public abstract void OnEnter();
        public abstract void OnExit();

        public abstract void Update();

        public abstract void FixedUpdate();
        #endregion
    }
}