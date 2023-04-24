using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _health = 100;
    private int _maxHealth = 100;
    private int _minHealth = 0;

    public int MaxHealth => _maxHealth;

    public static event Action<float> Flamed;
    public static event Action<float> Iced;
    public static event Action<float> Bleeded;
    public event Action Died;
    public event Action<float> TakedDamage;
    public event Action<float> HealthChanged;

    private void OnParticleCollision(GameObject other)
    {
        if (other.TryGetComponent(out Flame flame))
        {
            Flamed?.Invoke(flame.DebuffDuration);
            TakeDamage(flame.MakeDamage());
        }
        if (other.TryGetComponent(out Freeze frostArrow))
        {
            Iced?.Invoke(frostArrow.DebuffDuration);
            TakeDamage(frostArrow.MakeDamage());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bleeding bleeding))
        {
            Bleeded?.Invoke(bleeding.DebuffDuration);
            TakeDamage(bleeding.MakeDamage());
        }
    }

    private void TakeDamage(float damage)
    {
        if (_health > _minHealth)
        {
            _health -= damage;
            TakedDamage?.Invoke(damage);
            HealthChanged?.Invoke(_health);
        }
        else
        {
            Died?.Invoke();
        }
    }
}