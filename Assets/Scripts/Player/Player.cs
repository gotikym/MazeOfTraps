using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _health = 100;
    private int _maxHealth = 100;
    private int _minHealth = 0;

    private int _money;

    public int Money => _money;
    public int MaxHealth => _maxHealth;

    public event Action<float> Flamed;
    public event Action<float> Freezed;
    public event Action<float> Bleeded;
    public event Action<float> TakedDamage;
    public event Action<float> HealthChanged;
    public event Action<int> MoneyChanged;
    public event Action Died;

    private void OnEnable()
    {
        _money = PlayerPrefs.GetInt("Money");
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.TryGetComponent(out Flame flame))
        {
            Flamed?.Invoke(flame.Duration);
            TakeDamage(flame.Damage);
        }
        if (other.TryGetComponent(out IceLance iceLance))
        {
            Freezed?.Invoke(iceLance.Duration);
            TakeDamage(iceLance.Damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Axe axe))
        {
            Bleeded?.Invoke(axe.Duration);
            TakeDamage(axe.Damage);
        }
    }

    public void TakeMoney(int money)
    {
        _money += money;
        MoneyChanged?.Invoke(_money);
        PlayerPrefs.SetInt("Money", _money);
    }

    private void TakeDamage(float damage)
    {
        _health -= damage;
        TakedDamage?.Invoke(damage);
        HealthChanged?.Invoke(_health);

        if (_health <= _minHealth)
            Died?.Invoke();
    }
}