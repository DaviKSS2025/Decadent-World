using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Events/AudioChannel")]
public class AudioEventChannel : ScriptableObject
{
    // Agora o evento avisa: "Alguém quer tocar ESSE som aqui"
    public event Action<SimpleAudioEvent> OnAudioRequested;

    public void RaiseEvent(SimpleAudioEvent sfxEvent)
    {
        OnAudioRequested?.Invoke(sfxEvent);
    }
}
