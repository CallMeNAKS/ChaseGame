using System.Collections;
using UnityEngine;

namespace CodeBase.Generics
{
    public class AttackBehavior : MonoBehaviour
    {
        [SerializeField] private int _damage = 3;
        private Team _team;
        private Coroutine _damageCoroutine;
        private Collider _targetCollider;


        private void Awake()
        {
            _team = GetComponent<ITeamable>().Team;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Health>(out var health) && other.GetComponent<ITeamable>()?.Team != _team)
            {
                _targetCollider = other;
                _damageCoroutine = StartCoroutine(PeriodicDamage(health));
            }
        }

        private IEnumerator PeriodicDamage(Health targetHealth)
        {
            while (true)
            {
                targetHealth.TakeDamage(_damage);
                yield return new WaitForSeconds(.5f);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (_targetCollider == other)
            {
                StopCoroutine(_damageCoroutine);
                _damageCoroutine = null;
            }
        }
    }
}