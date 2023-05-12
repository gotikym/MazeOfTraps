using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public abstract class EndGamePanel : MonoBehaviour
{
    [SerializeField] protected GameObject Panel;
    [SerializeField] protected GameObject LoadScreen;
    [SerializeField] protected AudioSource AudioSource;
    [SerializeField] protected AudioMixerGroup MixerGroup;

    protected const string EndGameSnapshotName = "EndGame";
    protected const string NormalSnapshotName = "Normal";

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
        MixerGroup.audioMixer.FindSnapshot(NormalSnapshotName).TransitionTo(0.5f);
    }

    public void OnMainMenuButtonClick()
    {
        LoadScreen.SetActive(true);
        MainMenu.Load();
        Time.timeScale = RunningTimeScale;
        MixerGroup.audioMixer.FindSnapshot(NormalSnapshotName).TransitionTo(1f);
    }

    public void OnNextLevelButtonClick()
    {
        Panel.SetActive(false);
        LoadScreen.SetActive(true);
        Time.timeScale = RunningTimeScale;
        MixerGroup.audioMixer.FindSnapshot(NormalSnapshotName).TransitionTo(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    protected void OpenPanel()
    {
        Panel.SetActive(true);
        Time.timeScale = StoppedTimeScale;
        MixerGroup.audioMixer.FindSnapshot(EndGameSnapshotName).TransitionTo(1f);
        AudioSource.Play();
    }
}