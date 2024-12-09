using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Bonus
{
    public class Bonus : MonoBehaviour
    {
        [SerializeField] private Player.Player _player;
        [SerializeField] private EnemyHunter _enemy;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player.Player>(out var player))
            {
                _player.ToggleState();
                _enemy.ToggleState();
                // gameObject.SetActive(false);
                StartCoroutine(BonusTimer());
            }
        }

        private IEnumerator BonusTimer()
        {
            yield return new WaitForSeconds(10f);
            _player.ToggleState();
            _enemy.ToggleState();
        }
    }
}