using UnityEngine;

public class ResetLevels : MonoBehaviour
{
    public void ResetLockOnRevels()
    {
        PlayerPrefs.DeleteKey("currentScene");
    }
}
