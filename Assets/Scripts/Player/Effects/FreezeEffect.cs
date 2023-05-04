using System.Collections;
using UnityEngine;

public class FreezeEffect : Effects
{
    [SerializeField] protected Player _player;
    [SerializeField] private Renderer _foxRenderer;
    [SerializeField] private Material _iceMaterial;

    private Material _defoultMaterial;


    private void Awake()
    {
        _defoultMaterial = _foxRenderer.material;
    }

    protected override void OnEnable()
    {
        _player.Freezed += OnIced;
    }

    protected override void OnDisable()
    {
        _player.Freezed -= OnIced;
    }

    private void OnIced(float duration)
    {
        _foxRenderer.material = _iceMaterial;
        _audioSource.Play();
        StartEffect(duration);
    }

    protected override IEnumerator StopEffect(float duration)
    {
        yield return new WaitForSeconds(duration);
        _foxRenderer.material = _defoultMaterial;
        _audioSource.Stop();
    }
}
