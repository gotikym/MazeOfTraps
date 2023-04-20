using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _palyer;
    [SerializeField] private Image _healthBarFilling;
    [SerializeField] private Gradient _gradient;

    private float _currentHealth;

    private void OnEnable()
    {
        _palyer.HealthChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _palyer.HealthChanged -= OnValueChanged;
    }

    public void OnValueChanged(float value)
    {
        _currentHealth = (float)value / _palyer.MaxHealth;
        _healthBarFilling.fillAmount = _currentHealth;
        _healthBarFilling.color = _gradient.Evaluate(_currentHealth);
    }
}