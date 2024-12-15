using CodeBase.Input;
using UnityEngine;

namespace CodeBase.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMover : MonoBehaviour
    {
        private CharacterController _characterController;
        private IInputHandler _input;
        
        [SerializeField] private float _moveSpeed = 10f;
        [SerializeField] private Animator _animator;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        public void SetInput(IInputHandler input)
        {
            _input = input;
        }

        private void Update()
        {
            var direction = new Vector3(_input.Direction.x, 0, _input.Direction.y);
            var angle = Vector3.Angle(transform.forward, direction);
            
            transform.Rotate(Vector3.up, angle);
            _characterController.Move(direction * Time.deltaTime * _moveSpeed);
            _animator.SetFloat("Speed", _characterController.velocity.magnitude);
        }
    }
}