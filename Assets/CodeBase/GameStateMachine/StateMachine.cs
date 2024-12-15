using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.GameStateMachine
{
    public enum StateType
    {
        Chase,
        CatchOut
    }

    public class StateMachine
    {
        private IGameState CurrentState { get; set; }
        private readonly Dictionary<StateType, IGameState> _states;


        public StateMachine() => _states = new Dictionary<StateType, IGameState>();

        public void AddState(StateType type, IGameState state)
        {
            _states.Add(type, state);
        }

        public void ChangeState(StateType type)
        {
            if (_states.TryGetValue(type, out IGameState state))
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