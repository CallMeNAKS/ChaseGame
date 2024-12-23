using UnityEngine;

namespace CodeBase.Generics
{
    public class LocomotionAnimation 
    {
        private Animator _animator;
        
        
        public LocomotionAnimation(Animator animator)
        {
            _animator = animator;
        }
        
        public void AnimateMove(float speed)
        {
            _animator.SetFloat("Speed", speed);
        }
    }
}