using System;
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
            _attackBehavior.enabled = false;
        }

        public void ToggleState()
        {
            _attackBehavior.enabled = !_attackBehavior.enabled;
        }
    }
}