using System;
using UnityEngine;

namespace CodeBase.Bonus
{
    public class Bonus : MonoBehaviour
    {
        public event Action BonusTaked;


        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player.Player>(out var player))
            {
                BonusTaked?.Invoke();
                
                gameObject.SetActive(false);
            }
        }

        public void Spawn()
        {
            gameObject.SetActive(true);
        }
    }
}