using System;
using UnityEngine;

public abstract class ShooseLevel : MonoBehaviour
{
    protected int Level;

    public static event Action<int> LevelShoosed;

    public void OnButtonClick()
    {
        LevelShoosed?.Invoke(Level);
    }
}
