using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _health = 100;

    private const string ParticleFlameStream = "FlameStream";
    private const string ParticleIceLance = "IceLance";

    public event Action HealthChanged;
    public event Action<float> Flamed;
    public event Action<float> Iced;

    private void OnParticleCollision(GameObject other)
    {
        if (other.TryGetComponent(out Flame flame))
        {
            Flamed?.Invoke(flame.DebuffDuration);
            Debug.Log(flame.damage);
        }
        if (other.TryGetComponent(out FrostArrow frostArrow))
        {
            Iced?.Invoke(frostArrow.DebuffDuration);
            Debug.Log(frostArrow.damage);
        }
    }
}