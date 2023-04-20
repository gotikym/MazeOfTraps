using System.Collections;
using UnityEngine;

public class ParticleTrap : Trap
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private float _duration;
    [SerializeField] private float _delay;

    private float _resetedTime = 0;

    protected override IEnumerator ActivateTrap()
    {
        yield return new WaitForSeconds(_delayBeforeStart);

        float currentDuration = _duration;

        while (true)
        {
            _particleSystem.Play();

            while (currentDuration > _resetedTime)
            {
                currentDuration -= Time.deltaTime;
                yield return null;
            }

            _particleSystem.Stop();

            yield return new WaitForSeconds(_delay);

            currentDuration = _duration;
        }
    }

    protected override void DeactivateTrap()
    {
        base.DeactivateTrap();
        _particleSystem.Stop();
    }
}