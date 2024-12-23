using System.Collections.Generic;

namespace CodeBase.Enemy
{
    public class EnemiesBehavior
    {
        private readonly List<EnemyHunter> _hunters;

        public EnemiesBehavior(List<EnemyHunter> hunters)
        {
            _hunters = hunters;
        }

        public void ChangeBehavior()
        {
            foreach (var hunter in _hunters)
                hunter.ToggleState();
        }
    }
}