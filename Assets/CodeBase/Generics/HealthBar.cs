using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Generics
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private Slider _slider;

        private void OnEnable()
        {
            _health.HealthChanged += OnHealthChange;
        }

        private void OnHealthChange(int currentHealth)
        {
            _slider.value = currentHealth;
        }

        private void OnDisable()
        {
            _health.HealthChanged -= OnHealthChange;
        }
    }
}