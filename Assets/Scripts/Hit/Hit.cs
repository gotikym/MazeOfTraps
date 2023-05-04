using UnityEngine;

public abstract class Hit : MonoBehaviour
{
    public abstract float Damage { get; }
    public abstract float Duration { get; }
}