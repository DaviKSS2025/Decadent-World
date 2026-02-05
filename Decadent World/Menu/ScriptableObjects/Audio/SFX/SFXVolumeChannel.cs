using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SFXVolumeChannel", menuName = "Audio/SFXVolumeChannel")]
public class SFXVolumeChannel : ScriptableObject
{
    public Action<float> OnSFXVolumeChanged;

    public void RaiseSFXVolumeChanged(float volume)
    {
        OnSFXVolumeChanged?.Invoke(volume);
    }
}