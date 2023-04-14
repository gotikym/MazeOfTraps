using System.Collections;
using UnityEngine;

public class Fireble : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Renderer _foxRenderer;
    [SerializeField] private Material _iceMaterial;
    [SerializeField] private ParticleSystem _fireEffect;

    private Material _defoultMaterial;
    private Coroutine _previosesTask;

    private void Awake()
    {
        _defoultMaterial = _foxRenderer.material;
    }

    private void OnEnable()
    {
        _player.Flamed += OnFlamed;
        _player.Iced += OnIced;
    }

    private void OnDisable()
    {
        _player.Flamed -= OnFlamed;
        _player.Iced -= OnIced;
    }

    public void OnFlamed()
    {        
        _fireEffect.Play();

        if (_previosesTask != null)
            StopCoroutine( _previosesTask );

        _previosesTask = StartCoroutine(StopEffect(2));
    }

    private IEnumerator StopEffect(float delay)
    {
        yield return new WaitForSeconds( delay );
        _fireEffect.Stop();
    }

    private void OnIced()
    {
        _foxRenderer.material = _iceMaterial;
        StartCoroutine(Unfreeze(1));
    }

    private IEnumerator Unfreeze(float delay)
    {
        yield return new WaitForSeconds(delay);
        _foxRenderer.material = _defoultMaterial;
    }
}
