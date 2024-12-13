using System.Collections;
using CodeBase.Enemy;
using CodeBase.Utils;
using UnityEngine;

namespace CodeBase.GameStateMachine
{
    public class CatchOutState : IGameState
    {
        private readonly Coroutines _coroutines;
        private readonly StateMachine _stateMachine;
        private readonly Bonus.Bonus _bonus;
        private readonly Player.Player _player;
        private readonly EnemyBehavior _enemyBehavior;

        private const float BONUS_DURATION = 10f;


        public CatchOutState(StateMachine stateMachine,
            Bonus.Bonus bonus,
            Coroutines coroutines,
            Player.Player player,
            EnemyBehavior enemyBehavior)
        {
            _stateMachine = stateMachine;
            _bonus = bonus;
            _coroutines = coroutines;
            _player = player;
            _enemyBehavior = enemyBehavior;
        }

        public void Enter()
        {
            _coroutines.StartCoroutine(StateTimer());
            _player.ToggleState();
            _enemyBehavior.ChangeBehavior();
        }

        public void Exit()
        {
            _bonus.Spawn();
            _player.ToggleState();
            _enemyBehavior.ChangeBehavior();
        }

        private IEnumerator StateTimer()
        {
            yield return new WaitForSeconds(BONUS_DURATION);
            _stateMachine.ChangeState(StateType.Chase);
        }
    }
}