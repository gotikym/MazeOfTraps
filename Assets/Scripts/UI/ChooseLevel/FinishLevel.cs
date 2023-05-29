using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private ActivateZone _finishZone;
    [SerializeField] private Player _player;
    [SerializeField] private int _rewardsCoin;

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
        PlayerPrefs.SetInt("currentScene", SceneManager.GetActiveScene().buildIndex);        
    }
}
