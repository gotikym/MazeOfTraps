using UnityEngine;

public abstract class Buff : MonoBehaviour
{
    public abstract string Name { get; }
    public abstract float Duration { get; }
    public abstract float Strength { get; }
}