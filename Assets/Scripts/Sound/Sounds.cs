using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class Sounds : MonoBehaviour
{
    [SerializeField] protected AudioClip[] _sounds;

    protected AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    protected void PlaySond(AudioClip audio, float volume = 1f, bool destroyed = false, float p1 = 0.85f, float p2 = 1.2f)
    {
        _audioSource.pitch = Random.Range(p1, p2);

        if (destroyed)
            AudioSource.PlayClipAtPoint(audio, transform.position, volume);
        else
            _audioSource.PlayOneShot(audio, volume);
    }
}