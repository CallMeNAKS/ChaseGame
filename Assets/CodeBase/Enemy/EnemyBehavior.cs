using System.Collections.Generic;

namespace CodeBase.Enemy
{
    public class EnemyBehavior
    {
        private readonly List<EnemyHunter> _hunters;

        public EnemyBehavior(List<EnemyHunter> hunters)
        {
            _hunters = hunters;
        }

        public void ChangeBehavior()
        {
            foreach (var hunter in _hunters)
            {
                hunter.ToggleState();
            }
        }
    }
}