using System;
using CodeBase.Input;
using CodeBase.Player;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private PlayerMover _playerMover;
        
        private KeyboardInput _keyboardInput;   

        private void Awake()
        {
            _keyboardInput = new KeyboardInput();
        }

        private void Start()
        {
            _playerMover.SetInput(_keyboardInput);
        }

        private void Update()
        {
            _keyboardInput.UpdateLocal();
        }
    }
}