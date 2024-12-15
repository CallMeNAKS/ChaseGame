using System.Collections.Generic;
using CodeBase.Enemy;
using CodeBase.GameStateMachine;
using CodeBase.Input;
using CodeBase.Player;
using CodeBase.Utils;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private PlayerMover _playerMover;
        [SerializeField] private Bonus.Bonus _bonus;
        [SerializeField] private List<EnemyHunter> _hunters;
        
        private KeyboardInput _keyboardInput;
        private StateMachine _stateMachine;
        private Coroutines _coroutines;
        private EnemyBehavior _enemyBehavior;

        private void Awake()
        {
            RegistrationServices();
            RegistrationStates();
            
            _stateMachine.ChangeState(StateType.Chase);
        }

        private void Start()
        {
            _playerMover.SetInput(_keyboardInput);
        }

        private void Update()
        {
            _keyboardInput.UpdateLocal();
        }

        private void RegistrationStates()
        {
            _stateMachine.AddState(StateType.Chase, new ChaseState(_stateMachine, _bonus));
            _stateMachine.AddState(StateType.CatchOut,
                new CatchOutState(_stateMachine,
                    _bonus, _coroutines,
                    _playerMover.GetComponent<Player.Player>(),
                    _enemyBehavior));
        }

        private void RegistrationServices()
        {
            _keyboardInput = new KeyboardInput();
            _stateMachine = new StateMachine();
            _enemyBehavior = new EnemyBehavior(_hunters);
            _coroutines = new GameObject("Coroutines").AddComponent<Coroutines>();
        }
    }
}