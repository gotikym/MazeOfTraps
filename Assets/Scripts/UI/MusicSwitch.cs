using UnityEngine;
using UnityEngine.UI;

public class MusicSwitch : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Sprite _iconMusicOn;
    [SerializeField] private Sprite _iconMusicOff;
    [SerializeField] private Image _musicButtonImage;

    private bool _isMusicOn;
    private const string NameKeyMusic = "music";
    private const int ValueMusicOn = 1;
    private const int ValueMusicOff = 0;

    private void Start()
    {
        _isMusicOn = true;
    }

    private void Update()
    {
        if(PlayerPrefs.GetInt(NameKeyMusic) == ValueMusicOff)
        {
            _musicButtonImage.sprite = _iconMusicOn;
            _audioSource.enabled = true;
            _isMusicOn = true;
        }
        else if(PlayerPrefs.GetInt(NameKeyMusic) == ValueMusicOn)
        {
            _musicButtonImage.sprite = _iconMusicOff;
            _audioSource.enabled = false;
            _isMusicOn = false;
        }
    }

    public void SwitchMusicPlaying()
    {
        if (_isMusicOn)
            PlayerPrefs.SetInt(NameKeyMusic, ValueMusicOn);
        else if (_isMusicOn == false)
            PlayerPrefs.SetInt(NameKeyMusic, ValueMusicOff);
    }
}
