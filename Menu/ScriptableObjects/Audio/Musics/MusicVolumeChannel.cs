using System;
using UnityEngine;

[CreateAssetMenu(fileName = "MusicVolumeChannel", menuName = "Audio/MusicVolumeChannel")]
public class MusicVolumeChannel : ScriptableObject
{
    public Action<float> OnMusicVolumeChanged;

    public void RaiseMusicVolumeChanged(float volume)
    {
        OnMusicVolumeChanged?.Invoke(volume);
    }
}
