using System.Collections;
using UnityEngine;

public abstract class Debuff : MonoBehaviour
{
    protected float Damage = 0f;
    protected float Duration = 0f;

    public float DebuffDuration => Duration;

    protected Coroutine _previosesTask;

    protected virtual void OnEnable() { }

    protected virtual void OnDisable() { }

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

    protected virtual IEnumerator StopEffect()
    {
        yield return new WaitForSeconds(Duration);
    }
}