using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Generics
{
    public class AttackBehavior : MonoBehaviour
    {
        [SerializeField] private int _damage = 3;
        private Collider _targetCollider;
        private bool _isAttacking;
        private Team _team;

        public bool IsActive { get; set; }


        private void Awake()
        {
            _team = GetComponent<ITeamable>().Team;
            _isAttacking = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsActive) return;

            if (other.TryGetComponent<Health>(out var health) && other.GetComponent<ITeamable>()?.Team != _team)
            {
                _targetCollider = other;
                _isAttacking = true;
                StartCoroutine(PeriodicDamage(health));
            }
        }

        private IEnumerator PeriodicDamage(Health targetHealth)
        {
            while (_isAttacking && IsActive)
            {
                targetHealth.TakeDamage(_damage);
                yield return new WaitForSeconds(.5f);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (_targetCollider == other)
            {
                _isAttacking = false;
            }
        }
    }
}