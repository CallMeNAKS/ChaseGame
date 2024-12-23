using CodeBase.Generics;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemy
{
    public class EnemyAnimation : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        private LocomotionAnimation _locomotionAnimation;
        private Animator _animator;
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _locomotionAnimation = new LocomotionAnimation(_animator);
        }

        private void Start()
        {
            _locomotionAnimation.AnimateMove(_navMeshAgent.speed);
        }
    }
}