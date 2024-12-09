using System;
using UnityEngine;

namespace CodeBase.Input
{
    public class KeyboardInput : IInputHandler
    {
        public Vector2 Direction { get; private set; }

        public void UpdateLocal()
        {
            Direction = new Vector2(UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical"));
        }
    }
}