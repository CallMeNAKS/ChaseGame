using System;
using UnityEngine;

namespace CodeBase.Input
{
    public class KeyboardInput : IInputHandler, IDisposable
    {
        private event Action _actionUpdate;
        public Vector2 Direction { get; private set; }

        public KeyboardInput(Action actionUpdate)
        {
            _actionUpdate = actionUpdate;
            _actionUpdate += Update;
            Debug.Log("Construct Input");
        }

        private void Update()
        {
            Debug.Log("Update Input");
            Direction = new Vector2(UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical"));
        }

        public void Dispose()
        {
            _actionUpdate -= Update;
        }
    }
}