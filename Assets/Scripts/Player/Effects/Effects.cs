using System.Collections;
using UnityEngine;

public abstract class Effects : MonoBehaviour
{
    [SerializeField] protected AudioSource _audioSource;

    protected Coroutine _previosesTask;

    protected abstract void OnEnable();

    protected abstract void OnDisable();

    protected abstract IEnumerator StopEffect(float duration);

    protected void StartEffect(float duration)
    {
        if (_previosesTask != null)
            StopCoroutine(_previosesTask);

        _previosesTask = StartCoroutine(StopEffect(duration));
    }
}