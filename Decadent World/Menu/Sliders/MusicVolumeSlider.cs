using UnityEngine;
public class MusicVolumeSlider : MenuBaseSlider
{
    [SerializeField] private MusicVolumeChannel _musicVolumeChannel;
    public void OnMusicVolumeUpdated()
    {
        _musicVolumeChannel.RaiseMusicVolumeChanged(_slider.value);
        PlayerPrefs.SetFloat("MusicVolume", _slider.value);
    }
}
