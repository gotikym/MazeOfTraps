using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _panel;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioMixerGroup _mixerGroup;

    private const string DiedSnapshotName = "Died";
    private const string NormalSnapshotName = "Normal";

    private int _stoppedTimeScale = 0;
    private int _runningTimeScale = 1;

    private void OnEnable()
    {
        _player.Died += OnDied;
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
    }

    private void OnDied()
    {
        _panel.SetActive(true);
        Time.timeScale = _stoppedTimeScale;
        _mixerGroup.audioMixer.FindSnapshot(DiedSnapshotName).TransitionTo(1f);
        _audioSource.Play();
    }

    public void OnRestartButtonClick()
    {
        _panel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        _mixerGroup.audioMixer.FindSnapshot(NormalSnapshotName).TransitionTo(1f);
        Time.timeScale = _runningTimeScale;
    }

    public void OnMainMenuButtonClick()
    {
        MainMenu.Load();
        _mixerGroup.audioMixer.FindSnapshot(NormalSnapshotName).TransitionTo(1f);
        Time.timeScale = _runningTimeScale;
    }
}