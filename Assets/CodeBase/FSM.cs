using System.Collections.Generic;
using UnityEngine;

namespace CodeBase
{
    public enum StateType
    {
        Chase,
        CatchOut
    }

    public class FSM
    {
        private FSMState CurrentState { get; set; }
        private Dictionary<StateType, FSMState> _states;


        public FSM() => _states = new Dictionary<StateType, FSMState>();

        public void AddState(StateType type, FSMState state)
        {
            _states.Add(type, state);
        }

        public void EnterState(StateType type)
        {
            if (_states.TryGetValue(type, out FSMState state))
            {
                CurrentState?.Exit();
                CurrentState = state;
                CurrentState.Enter();

                return;
            }
            Debug.LogError("Такого состояния нет!");
        }
    }
}