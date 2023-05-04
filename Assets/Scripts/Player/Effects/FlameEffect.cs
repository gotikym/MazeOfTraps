using System.Collections;
using UnityEngine;

public class FlameEffect : Effects
{
    [SerializeField] protected Player _player;
    [SerializeField] private ParticleSystem _fireEffect;

    protected override void OnEnable()
    {
        _player.Flamed += OnFlamed;
    }

    protected override void OnDisable()
    {
        _player.Flamed -= OnFlamed;
    }

    public void OnFlamed(float duration)
    {
        _fireEffect.Play();
        _audioSource.Play();
        StartEffect(duration);
    }

    protected override IEnumerator StopEffect(float duration)
    {
        yield return new WaitForSeconds(duration);
        _fireEffect.Stop();
        _audioSource.Stop();
    }
}
