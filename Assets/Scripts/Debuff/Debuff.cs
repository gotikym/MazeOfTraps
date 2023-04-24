using System.Collections;
using UnityEngine;

public abstract class Debuff : MonoBehaviour
{
    [SerializeField] protected AudioSource _audioSource;

    protected float Damage = 0f;
    protected float Duration = 0f;

    public float DebuffDuration => Duration;

    protected Coroutine _previosesTask;

    protected abstract void OnEnable();

    protected abstract void OnDisable();

    public float MakeDamage()
    {
        return Damage;
    }

    protected void StartEffect()
    {
        if (_previosesTask != null)
            StopCoroutine(_previosesTask);

        _previosesTask = StartCoroutine(StopEffect());
    }

    protected abstract IEnumerator StopEffect();
}