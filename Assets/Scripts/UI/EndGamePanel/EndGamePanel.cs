using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public abstract class EndGamePanel : MonoBehaviour
{
    [SerializeField] protected GameObject _panel;
    [SerializeField] protected AudioSource _audioSource;
    [SerializeField] protected AudioMixerGroup _mixerGroup;

    protected const string DiedSnapshotName = "EndGame";
    protected const string NormalSnapshotName = "Normal";

    protected int _stoppedTimeScale = 0;
    protected int _runningTimeScale = 1;

    protected abstract void OnEnable();

    protected abstract void OnDisable();

    public void OnRestartButtonClick()
    {
        _panel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = _runningTimeScale;
        _mixerGroup.audioMixer.FindSnapshot(NormalSnapshotName).TransitionTo(0.5f);
    }

    public void OnMainMenuButtonClick()
    {
        MainMenu.Load();
        Time.timeScale = _runningTimeScale;
        _mixerGroup.audioMixer.FindSnapshot(NormalSnapshotName).TransitionTo(1f);
    }

    protected void OpenPanel()
    {
        _panel.SetActive(true);
        Time.timeScale = _stoppedTimeScale;
        _mixerGroup.audioMixer.FindSnapshot(DiedSnapshotName).TransitionTo(1f);
        _audioSource.Play();
    }
}