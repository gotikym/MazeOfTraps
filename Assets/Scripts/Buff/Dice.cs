using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour
{
    [SerializeField] private ParticleSystem _destroyEffect;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private List<Buff> _buffs;

    private float _destroyTimer = 2f;

    public static event Action<Buff> Buffed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _destroyEffect.Play();
            _audioSource.Play();
            Buffed?.Invoke(GetBuff());
            StartCoroutine(Destroy());
        }
    }

    private Buff GetBuff()
    {
        int minNumberBuff = 0;
        int maxNumberBuff = _buffs.Count;

        return _buffs[Random.Range(minNumberBuff, maxNumberBuff)];
    }

    private IEnumerator Destroy()
    {
        if (gameObject.TryGetComponent(out BoxCollider boxCollider))
            Destroy(boxCollider);

        yield return new WaitForSeconds(_destroyTimer);
        Destroy(gameObject);
    }
}