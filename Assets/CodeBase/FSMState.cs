namespace CodeBase
{
    public abstract class FSMState
    {
        protected readonly FSM _fsm;
        protected Bonus.Bonus _bonus;

        public FSMState(FSM fsm, Bonus.Bonus bonus)
        {
            _fsm = fsm;
            _bonus = bonus;
        }

        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }
    }


    public class ChaseState : FSMState
    {
        public ChaseState(FSM fsm, Bonus.Bonus bonus) : base(fsm, bonus) { }

        public override void Enter()
        {
            _bonus.OnChangeBonusState += SwapState;
        }

        private void SwapState(bool isNeeded)
        {
            if (isNeeded)
            {
                _fsm.EnterState(StateType.CatchOut);
            }
        }
    }

    public class CatchOutState : FSMState
    {
        public CatchOutState(FSM fsm, Bonus.Bonus bonus) : base(fsm, bonus) { }

        public override void Enter()
        {
            _bonus.OnChangeBonusState += SwapState;
        }

        private void SwapState(bool isNeeded)
        {
            if (!isNeeded)
            {
                _fsm.EnterState(StateType.Chase);
            }
        }
    }
}