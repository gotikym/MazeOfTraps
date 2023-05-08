using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinPanel : EndGamePanel
{
    [SerializeField] private ActivateZone _finish;

    protected override void OnEnable()
    {
        _finish.Entered += OpenPanel;
    }

    protected override void OnDisable()
    {
        _finish.Entered -= OpenPanel;
    }

    protected override void OpenPanel()
    {
        base.OpenPanel();
        PlayerPrefs.SetInt("currentScene", SceneManager.GetActiveScene().buildIndex);
    }
}