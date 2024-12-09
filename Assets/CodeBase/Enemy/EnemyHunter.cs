using System.Collections;
using CodeBase;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyHunter : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] private int _damage = 5;
    [SerializeField] private Transform _playerTransform;
    private Coroutine _periodicDamageCoroutine;
    private NavMeshAgent _navMeshAgent;
    private Collider _playerCollider;
    

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _navMeshAgent.SetDestination(_playerTransform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent<Health>(out var playerHealth))
        {
            _playerCollider = other;
            _periodicDamageCoroutine = StartCoroutine(PeriodicDamage(playerHealth));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_playerCollider == other)
        {
            StopCoroutine(_periodicDamageCoroutine);
            _periodicDamageCoroutine = null;
        }
    }

    private IEnumerator PeriodicDamage(Health playerHealth)
    {
        while (true)
        {
            playerHealth.TakeDamage(_damage);
            yield return new WaitForSeconds(.5f);
        }
    }
}