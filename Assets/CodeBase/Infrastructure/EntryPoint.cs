using System;
using CodeBase.Input;
using CodeBase.Player;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private PlayerMover _playerMover;
        [SerializeField] private Bonus.Bonus _bonus;
        private KeyboardInput _keyboardInput;
        private FSM _fsm;

        private void Awake()
        {
            _keyboardInput = new KeyboardInput();
            _fsm = new FSM();
            
            _fsm.AddState(StateType.Chase, new ChaseState(_fsm, _bonus));
            _fsm.AddState(StateType.CatchOut, new CatchOutState(_fsm, _bonus));
            
            _fsm.EnterState(StateType.Chase);
        }

        private void Start()
        {
            _playerMover.SetInput(_keyboardInput);
        }

        private void Update()
        {
            _keyboardInput.UpdateLocal();
        }
    }
}