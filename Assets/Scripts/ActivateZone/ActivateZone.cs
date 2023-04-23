using System;
using UnityEngine;

public  class ActivateZone : MonoBehaviour
{
    public event Action Entered;
    public event Action Exited;

    protected void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            Entered?.Invoke();
    }

    protected void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            Exited?.Invoke();
    }
}