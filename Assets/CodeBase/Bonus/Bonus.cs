using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Bonus
{
    public class Bonus : MonoBehaviour
    {
        public event Action<bool> OnChangeBonusState;
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
            OnChangeBonusState?.Invoke(false); //бонус исчез
            yield return new WaitForSeconds(10f);
            OnChangeBonusState?.Invoke(true); //бонус появился
            _player.ToggleState();
            _enemy.ToggleState();
        }
    }
}