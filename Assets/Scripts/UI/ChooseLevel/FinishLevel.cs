using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private ActivateZone _finishZone;
    [SerializeField] private Player _player;
    [SerializeField] private int _rewardsCoin;

    private const string PlayerPrefsUnlockedMapsKey = "unlockedMaps";

    private void OnEnable()
    {
        _finishZone.Entered += FinishLvl;
    }

    private void OnDisable()
    {
        _finishZone.Entered -= FinishLvl;
    }

    public void FinishLvl()
    {
        _player.TakeMoney(_rewardsCoin);
        PlayerPrefs.SetInt(PlayerPrefsUnlockedMapsKey, SceneManager.GetActiveScene().buildIndex);
    }
}
