using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundValueSwitch : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private AudioSource _effectSound;
    [SerializeField] private Image _swithcerIcon;
    [SerializeField] private Sprite _soundOnSprite;
    [SerializeField] private Sprite _soundOffSprite;

    private bool _soundOn;
    private const string SoundPlaying = "MusicPlaying";
    
    private void Awake()
    {
        GetCurrentState();
    }

    private void ChechSoundState()
    {
        if (PlayerPrefs.GetFloat(SoundPlaying) == 1)
        {
            _soundOn = true;
            _swithcerIcon.sprite = _soundOffSprite;
        }
        if (PlayerPrefs.GetFloat(SoundPlaying) == 0)
        {
            _soundOn = false;
            _swithcerIcon.sprite = _soundOnSprite;
        }
        _backgroundMusic.mute = _soundOn;
        _effectSound.mute = _soundOn;
    }

    private void GetCurrentState()
    {
        if (!PlayerPrefs.HasKey(SoundPlaying))
        {
            PlayerPrefs.SetFloat(SoundPlaying, 1);
            _soundOn = true;
        }
        else
            ChechSoundState();
    }

    public void ChangeSoundState()
    {
        _soundOn = !_soundOn;
        if (_soundOn)
            PlayerPrefs.SetFloat(SoundPlaying, 1);
        else
            PlayerPrefs.SetFloat(SoundPlaying, 0);
        ChechSoundState();
    }
}
