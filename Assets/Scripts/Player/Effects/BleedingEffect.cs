using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleedingEffect : Effects
{
    [SerializeField] protected Player _player;
    [SerializeField] private ParticleSystem _bleedingEffect;

    protected override void OnEnable()
    {
        _player.Bleeded += OnBleeded;
    }

    protected override void OnDisable()
    {
        _player.Bleeded -= OnBleeded;
    }

    public void OnBleeded(float duration)
    {
        _bleedingEffect.Play();
        _audioSource.Play();
        StartEffect(duration);
    }

    protected override IEnumerator StopEffect(float duration)
    {
        yield return new WaitForSeconds(duration);
        _bleedingEffect.Stop();
        _audioSource.Stop();
    }
}
