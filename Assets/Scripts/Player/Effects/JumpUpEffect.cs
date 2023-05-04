using System.Collections;
using UnityEngine;

public class JumpUpEffect : Effects
{
    [SerializeField] private ParticleSystem _jumpEffect;

    private const string BuffJumpName = "Jump";
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
        if(buff.Name == BuffJumpName)
        {
            _jumpEffect.Play();
            _audioSource.Play();
            StartEffect(buff.Duration);
        }
    }

    protected override IEnumerator StopEffect(float duration)
    {
        yield return new WaitForSeconds(duration);
        _jumpEffect.Stop();
        _audioSource.Stop();
    }
}
