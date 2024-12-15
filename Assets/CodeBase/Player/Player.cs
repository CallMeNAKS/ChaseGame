using CodeBase.Generics;
using UnityEngine;

namespace CodeBase.Player
{
    public class Player : MonoBehaviour, ITeamable
    {
        [SerializeField] private AttackBehavior _attackBehavior;
        [field: SerializeField]
        public Team Team { get; private set; }

        private void Awake()
        {
            _attackBehavior.IsActive = false;
        }

        public void ToggleState()
        {
            _attackBehavior.IsActive = !_attackBehavior.IsActive;
        }
    }
}