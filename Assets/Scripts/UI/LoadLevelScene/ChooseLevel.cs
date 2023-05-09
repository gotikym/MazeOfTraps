using System;
using UnityEngine;

public abstract class ChooseLevel : MonoBehaviour
{
    protected int Level;

    public static event Action<int> LevelChoosed;

    public void OnChooseLevel()
    {
        LevelChoosed?.Invoke(Level);
    }
}
