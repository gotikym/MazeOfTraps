using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MapDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text mapName;
    [SerializeField] private TMP_Text mapDescription;
    [SerializeField] private Image mapImage;
    [SerializeField] private Button playButton;
    [SerializeField] private GameObject lockImage;
    [SerializeField] private GameObject _loadScreen;
    [SerializeField] protected AudioMixerGroup _mixerGroup;

    private const string NormalSnapshotName = "Normal";
    private int _runningTimeScale = 1;
    
    private string _sceneName;

    public void DisplayMap(Map map)
    {
        mapName.text = map.Name;
        mapDescription.text = map.Description;
        mapImage.sprite = map.Image;
        _sceneName = map.SceneName;

        bool mapUnlocked = PlayerPrefs.GetInt("currentScene", 0) >= map.Index;

        lockImage.SetActive(!mapUnlocked);
        playButton.interactable = mapUnlocked;

        if (mapUnlocked)
            mapImage.color = Color.white;
        else
            mapImage.color = Color.grey;
    }

    public void LoadScene()
    {
        Time.timeScale = _runningTimeScale;
        _mixerGroup.audioMixer.FindSnapshot(NormalSnapshotName).TransitionTo(0.5f);
        _loadScreen.SetActive(true);
        SceneManager.LoadScene(_sceneName);
    }
}
