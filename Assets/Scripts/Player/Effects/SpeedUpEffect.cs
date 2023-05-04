using System.Collections;
using UnityEngine;

public class SpeedUpEffect : Effects
{
    [SerializeField] private ParticleSystem _speedEffect;

    private const string BuffSpeedName = "Speed";

    protected override void OnEnable()
    {
        Dice.Buffed += OnBuffed;
    }

    protected override void OnDisable()
    {
        Dice.Buffed -= OnBuffed;
    }

    private void OnBuffed(Buff buff)
    {
        if (buff.Name == BuffSpeedName)
        {
            _speedEffect.Play();
            _audioSource.Play();
            StartEffect(buff.Duration);
        }
    }

    protected override IEnumerator StopEffect(float duration)
    {
        yield return new WaitForSeconds(duration);
        _speedEffect.Stop();
        _audioSource.Stop();
    }
}
