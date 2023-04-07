using UnityEngine;
using UnityEngine.Events;

public class ActivateZone : MonoBehaviour
{
    public event UnityAction Entered;
    public event UnityAction Exited;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Entered?.Invoke();
            Debug.Log("вошли в зону активации");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Exited?.Invoke();
            Debug.Log("вышли из зоны активации");
        }
    }
}
