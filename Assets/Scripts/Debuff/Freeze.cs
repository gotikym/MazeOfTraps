using System;
using System.Collections;
using UnityEngine;

public class Freeze : Debuff
{
    [SerializeField] private Renderer _foxRenderer;
    [SerializeField] private Material _iceMaterial;

    private Material _defoultMaterial;

    private Freeze()
    {
        Damage = 10;
        Duration = 1;
    }

    private void Awake()
    {
        _defoultMaterial = _foxRenderer.material;
    }

    protected override void OnEnable()
    {
        Player.Iced += OnIced;
    }

    protected override void OnDisable()
    {
        Player.Iced -= OnIced;
    }

    private void OnIced(float debuffDuration)
    {
        _foxRenderer.material = _iceMaterial;

        StartEffect();
    }

    protected override IEnumerator StopEffect()
    {
        yield return new WaitForSeconds(Duration);
        _foxRenderer.material = _defoultMaterial;
    }
}