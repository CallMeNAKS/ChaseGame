using CodeBase.Generics;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyHunter : MonoBehaviour, ITeamable
{
    [SerializeField] private AttackBehavior _attackBehavior;
    [SerializeField] private Transform _playerTransform;
    private NavMeshAgent _navMeshAgent;
    private bool _isCatching = true;

    [field: SerializeField] public Team Team { get; private set; }


    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_isCatching)
        {
            RunOnPlayer();
        }
        else
        {
            RunAwayFromPlayer();
        }
    }

    private void RunOnPlayer()
    {
        _navMeshAgent.ResetPath();
        _navMeshAgent.SetDestination(_playerTransform.position);
    }

    private void RunAwayFromPlayer()
    {
        _navMeshAgent.ResetPath();
        var direction = transform.position - _playerTransform.position;
        _navMeshAgent.Move(direction * Time.deltaTime);
    }

    public void ToggleState()
    {
        _isCatching = !_isCatching;
        _attackBehavior.enabled = !_attackBehavior.enabled;
    }
}