using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleeding : Debuff
{
    [SerializeField] private ParticleSystem _bleedingEffect;

    private Bleeding()
    {
        Damage = 35f;
        Duration = 1;
    }

    protected override void OnEnable()
    {
        Player.Bleeded += OnBleeded;
    }

    protected override void OnDisable()
    {
        Player.Bleeded -= OnBleeded;
    }

    public void OnBleeded(float debuffDuration)
    {
        _bleedingEffect.Play();
        StartEffect();
    }

    protected override IEnumerator StopEffect()
    {
        yield return new WaitForSeconds(Duration);
        _bleedingEffect.Stop();
    }
}
