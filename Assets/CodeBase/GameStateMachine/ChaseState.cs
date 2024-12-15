namespace CodeBase.GameStateMachine
{
    public class ChaseState : IGameState
    {
        private readonly StateMachine _stateMachine;
        private readonly Bonus.Bonus _bonus;

        public ChaseState(StateMachine stateMachine, Bonus.Bonus bonus)
        {
            _stateMachine = stateMachine;
            _bonus = bonus;
        }

        public void Enter()
        {
            _bonus.BonusTaked += OnBonusTaked;
        }

        public void Exit()
        {
            _bonus.BonusTaked -= OnBonusTaked;
        }

        private void OnBonusTaked()
        {
            _stateMachine.ChangeState(StateType.CatchOut);
        }
    }
}