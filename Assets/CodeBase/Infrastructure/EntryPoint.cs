using System;
using CodeBase.Input;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        private KeyboardInput _keyboardInput;
        
        public event Action Updated;

        private void Awake()
        {
            _keyboardInput = new KeyboardInput(Updated);
        }

        private void Update()
        {
            Updated?.Invoke();
            
            
        }
    }
}