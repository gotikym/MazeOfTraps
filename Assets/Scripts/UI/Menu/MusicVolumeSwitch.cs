using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicVolumeSwitch : MonoBehaviour
{
    [SerializeField] private Sprite _iconMusicOn;
    [SerializeField] private Sprite _iconMusicOff;
    [SerializeField] private Image _musicButtonImage;
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;

    private const string NameKeyMusic = "music";
    private const string NameMixerGroupMusic = "MusicVolume";
    private const string NameMixerGroupEffect = "EffectVolume";
    private const float MinVolumeMixer = -80f;
    private const float MaxVolumeMixer = 0f;
    private const int ValueMusicOn = 1;
    private const int ValueMusicOff = 0;

    private bool _isMusicOn;

    private void Start()
    {
        _isMusicOn = true;
        _musicSlider.value = PlayerPrefs.GetFloat(NameMixerGroupMusic);
        _sfxSlider.value = PlayerPrefs.GetFloat(NameMixerGroupEffect);
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt(NameKeyMusic) == ValueMusicOff)
        {
            _musicButtonImage.sprite = _iconMusicOn;
            AudioListener.volume = ValueMusicOn;
            _isMusicOn = true;
        }
        else if (PlayerPrefs.GetInt(NameKeyMusic) == ValueMusicOn)
        {
            _musicButtonImage.sprite = _iconMusicOff;
            AudioListener.volume = ValueMusicOff;
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

    public void ChangeVolumeMusic(float volume)
    {
        _mixer.audioMixer.SetFloat(NameMixerGroupMusic, Mathf.Lerp(MinVolumeMixer, MaxVolumeMixer, volume));

        PlayerPrefs.SetFloat(NameMixerGroupMusic, volume);
    }

    public void ChangeVolumeSFX(float volume)
    {
        _mixer.audioMixer.SetFloat(NameMixerGroupEffect, Mathf.Lerp(MinVolumeMixer, MaxVolumeMixer, volume));

        PlayerPrefs.SetFloat(NameMixerGroupEffect, volume);
    }
}
