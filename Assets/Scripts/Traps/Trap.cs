using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private ActivateZone _activateZone;

    private void OnEnable()
    {
        _activateZone.Entered += OnEnteredActivateZone;
        _activateZone.Exited += OnExitedActivateZone;
    }

    private void OnDisable()
    {
        _activateZone.Entered -= OnEnteredActivateZone;
        _activateZone.Exited -= OnExitedActivateZone;
    }

    private void OnEnteredActivateZone()
    {
        _particleSystem.Play();
    }

    private void OnExitedActivateZone()
    {
        _particleSystem.Stop();
    }
}
