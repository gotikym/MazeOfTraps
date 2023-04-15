using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _health = 100;

    private const string ParticleFlameStream = "FlameStream";
    private const string ParticleIceLance = "IceLance";

    public event Action HealthChanged;
    public event Action Flamed;
    public event Action Iced;

    private void OnParticleCollision(GameObject other)
    {
        if (other.name == ParticleFlameStream)
            Flamed?.Invoke();
        if (other.name == ParticleIceLance)
            Iced?.Invoke();
    }
}