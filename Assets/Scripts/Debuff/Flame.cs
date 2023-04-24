using System.Collections;
using UnityEngine;

public class Flame : Debuff
{
    [SerializeField] private ParticleSystem _fireEffect;

    private Flame()
    {
        Damage = 0.5f;
        Duration = 1;
    }

    protected override void OnEnable()
    {
        Player.Flamed += OnFlamed;
    }

    protected override void OnDisable()
    {
        Player.Flamed -= OnFlamed;
    }

    public void OnFlamed(float debuffDuration)
    {
        _fireEffect.Play();
        _audioSource.Play();
        StartEffect();
    }

    protected override IEnumerator StopEffect()
    {
        yield return new WaitForSeconds(Duration);
        _fireEffect.Stop();
        _audioSource.Stop();
    }
}