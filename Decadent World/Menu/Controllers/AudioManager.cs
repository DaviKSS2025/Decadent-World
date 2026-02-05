using UnityEngine;
using UnityEngine.Audio;

/// <summary>
///Central audio controller.
///Listens to audio event channels and routes SFX and Music playback
///through dedicated AudioSources and an AudioMixer for global volume control.
///AudioManager does not know who requests sounds.
///It only reacts to raised audio events, keeping systems decoupled.
/// </summary>
public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _SFXSource;
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioEventChannel _audioChannel;
    [SerializeField] private MusicEventChannel _musicChannel;
    [SerializeField] private AudioMixer _globalVolumeGroup; // Controls global Music/SFX volumes
    [SerializeField] private SimpleMusicEvent _menuStartMusic; // Music played on menu startup
    [SerializeField] private MusicVolumeChannel _musicVolumeChannel;
    [SerializeField] private SFXVolumeChannel _SFXVolumeChannel;

    private void OnEnable()
    {
        _audioChannel.OnAudioRequested += PlaySFX;
        _musicChannel.OnMusicRequested += PlayMusic;
        _musicVolumeChannel.OnMusicVolumeChanged += UpdateMusicVolume;
        _SFXVolumeChannel.OnSFXVolumeChanged += UpdateSFXVolume;
    }
    private void OnDisable() 
    {
        _audioChannel.OnAudioRequested -= PlaySFX;
        _musicChannel.OnMusicRequested -= PlayMusic;
        _musicVolumeChannel.OnMusicVolumeChanged -= UpdateMusicVolume;
        _SFXVolumeChannel.OnSFXVolumeChanged -= UpdateSFXVolume;
    }
    private void Start()
    {
        // Start menu music and apply saved volume preferences
        _musicChannel.RaiseEvent(_menuStartMusic);
        UpdateMusicVolume(PlayerPrefs.GetFloat("MusicVolume", 0.5f));
        UpdateSFXVolume(PlayerPrefs.GetFloat("SFXVolume", 0.5f));
    }

    private void PlaySFX(SimpleAudioEvent sfx)
    {
        sfx.Play(_SFXSource);
    }
    private void PlayMusic(SimpleMusicEvent sfx)
    {
        sfx.Play(_musicSource);
    }

    private void UpdateMusicVolume(float musicVolume)
    {
        _globalVolumeGroup.SetFloat("MusicVolume", Mathf.Log10(ClampVolume(musicVolume)) * 20f);
    }

    private void UpdateSFXVolume(float SFXVolume) 
    {
        _globalVolumeGroup.SetFloat("SFXVolume", Mathf.Log10(ClampVolume(SFXVolume)) * 20f);
    }

    private float ClampVolume(float originalVolume)
    {
        return Mathf.Clamp(originalVolume, 0.0001f, 1f);
    }
}
