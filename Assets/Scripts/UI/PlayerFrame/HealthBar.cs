using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _palyer;
    [SerializeField] private Image _healthBarFilling;
    [SerializeField] private Image _secondHealthBarFilling;
    [SerializeField] private Gradient _gradient;

    private float _delay = 1f;
    private float _speedRemovingDamage = 0.01f;

    private float _currentHealth;
    private Coroutine _previosesTask;

    private void OnEnable()
    {
        _palyer.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _palyer.HealthChanged -= OnHealthChanged;
    }

    public void OnHealthChanged(float value)
    {
        _currentHealth = (float)value / _palyer.MaxHealth;
        _healthBarFilling.fillAmount = _currentHealth;
        _healthBarFilling.color = _gradient.Evaluate(_currentHealth);

        if (_previosesTask != null)
            StopCoroutine(_previosesTask);

        _previosesTask = StartCoroutine(RemoveFilledDamage());
    }

    private IEnumerator RemoveFilledDamage()
    {
        yield return new WaitForSeconds(_delay);

        while (_secondHealthBarFilling.fillAmount > _currentHealth)
        {
            _secondHealthBarFilling.fillAmount -= _speedRemovingDamage;
            yield return null;
        }
    }
}