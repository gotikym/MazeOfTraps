using UnityEngine;

public class Menu : MonoBehaviour
{
    private int _stoppedTimeScale = 0;
    private int _runningTimeScale = 1;

    public void OpenPannel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = _stoppedTimeScale;
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = _runningTimeScale;
    }

    public void CloseSubPanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}