using UnityEngine;
public class SFXVolumeSlider : MenuBaseSlider
{
    [SerializeField] private SFXVolumeChannel _SFXVolumeChannel;
    public void OnSFXVolumeUpdated()
    {
        _SFXVolumeChannel.RaiseSFXVolumeChanged(_slider.value);
        PlayerPrefs.SetFloat("SFXVolume", _slider.value);
    }
}
