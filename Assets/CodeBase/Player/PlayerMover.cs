using CodeBase.Generics;
using CodeBase.Input;
using UnityEngine;

namespace CodeBase.Player
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(Animator))]
    public class PlayerMover : MonoBehaviour
    {
        private IInputHandler _input;
        private Animator _animator;
        private CharacterController _characterController;
        private LocomotionAnimation _locomotionAnimation;

        [SerializeField] private float _moveSpeed = 10f;


        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _characterController = GetComponent<CharacterController>();
            _locomotionAnimation = new LocomotionAnimation(_animator);
        }

        public void SetInput(IInputHandler input)
        {
            _input = input;
        }

        private void Update()
        {
            var direction = new Vector3(_input.Direction.x, 0, _input.Direction.y);
            transform.forward = direction == Vector3.zero ? Vector3.forward : direction;

            _characterController.Move(direction * Time.deltaTime * _moveSpeed);
            _locomotionAnimation.AnimateMove(_characterController.velocity.magnitude);
        }
    }
}