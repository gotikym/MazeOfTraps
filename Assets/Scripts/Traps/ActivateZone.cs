using System;
using UnityEngine;

public class ActivateZone : MonoBehaviour
{
    public event Action Entered;
    public event Action Exited;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            Entered?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            Exited?.Invoke();
    }
}