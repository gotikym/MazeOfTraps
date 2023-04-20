using System.Collections;
using UnityEngine;

public abstract class Trap : MonoBehaviour
{
    [SerializeField] private ActivateZone _activateZone;
    [SerializeField] protected float _delayBeforeStart;

    private Coroutine _activateTrap;

    private void OnEnable()
    {
        _activateZone.Entered += OnEnteredActivateZone;
        _activateZone.Exited += OnExitedActivateZone;
    }

    private void OnDisable()
    {
        _activateZone.Entered -= OnEnteredActivateZone;
        _activateZone.Exited -= OnExitedActivateZone;
    }

    protected virtual IEnumerator ActivateTrap()
    {
        yield return new WaitForSeconds(_delayBeforeStart);
    }

    protected virtual void DeactivateTrap()
    {
        StopCoroutine(_activateTrap);        
    }

    private void OnEnteredActivateZone()
    {
        _activateTrap = StartCoroutine(ActivateTrap());
    }

    private void OnExitedActivateZone()
    {
        DeactivateTrap();
    }
}