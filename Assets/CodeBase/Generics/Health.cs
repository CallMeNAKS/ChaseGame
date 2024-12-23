using System;
using UnityEngine;

namespace CodeBase.Generics
{
    public class Health : MonoBehaviour
    {
        private int _health = 100;
        public event Action<int> HealthChanged;
        public event Action Death;


        private void Awake()
        {
            HealthChanged += OnHited;
            Death += OnDeath;
        }

        private void OnHited(int _)
        {
            // print("Health " + _health);
        }

        private void OnDeath()
        {
            // print("Death");
        }
        
        public void TakeDamage(int damage)
        {
            if (damage <= 0)
            {
                return;
            }
            
            _health -= damage;

            if (_health - damage <= 0)
            {
                _health = 0;
                Death?.Invoke();
            }
            
            HealthChanged?.Invoke(_health);
        }
    }
}