using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public abstract class EndGamePanel : MonoBehaviour
{
    [SerializeField] protected GameObject Panel;
    [SerializeField] protected GameObject LoadScreen;
    [SerializeField] protected AudioSource BackGroundMusic;
    [SerializeField] protected AudioSource EndGameMusic;
    [SerializeField] protected AudioMixerGroup MixerGroup;

    protected int StoppedTimeScale = 0;
    protected int RunningTimeScale = 1;
    protected int NextSceneIndex = 1;

    protected abstract void OnEnable();

    protected abstract void OnDisable();

    public void OnRestartButtonClick()
    {
        Panel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = RunningTimeScale;
    }

    public void OnMainMenuButtonClick()
    {
        LoadScreen.SetActive(true);
        MainMenu.Load();
        Time.timeScale = RunningTimeScale;
    }

    public void OnNextLevelButtonClick()
    {
        Panel.SetActive(false);
        LoadScreen.SetActive(true);
        Time.timeScale = RunningTimeScale;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + NextSceneIndex);
    }

    protected void OpenPanel()
    {
        Panel.SetActive(true);
        Time.timeScale = StoppedTimeScale;
        BackGroundMusic.Stop();
        EndGameMusic.Play();
    }
}