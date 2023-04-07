using System;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _health = 100;

    public event Action HealthChanged;


    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("попали");
    }
}
