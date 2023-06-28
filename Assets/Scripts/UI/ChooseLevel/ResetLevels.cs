using UnityEngine;

public class ResetLevels : MonoBehaviour
{
    private const string PlayerPrefsUnlockedMapsKey = "unlockedMaps";

    public void ResetLockOnRevels()
    {
        PlayerPrefs.DeleteKey(PlayerPrefsUnlockedMapsKey);
    }
}
