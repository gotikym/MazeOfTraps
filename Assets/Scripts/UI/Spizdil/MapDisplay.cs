using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MapDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text mapName;
    [SerializeField] private TMP_Text mapDescription;
    [SerializeField] private Image mapImage;
    [SerializeField] private Button playButton;
    [SerializeField] private GameObject lockImage;
    [SerializeField] private GameObject _loadScreen;

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
        _loadScreen.SetActive(true);
        SceneManager.LoadScene(_sceneName);
    }
}
