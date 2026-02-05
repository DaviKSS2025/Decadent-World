using UnityEngine;
using System;

// Event channel responsible for decoupling fullscreen UI controls
// from the system that applies fullscreen changes.
[CreateAssetMenu(fileName = "FullScreenToggleChannel", menuName = "Scriptable Objects/FullScreenToggleChannel")]
public class FullScreenToggleChannel : ScriptableObject
{
    // Raised when the fullscreen option is requested (e.g. UI button pressed)
    public Action OnFullScreenOptionChanges;

    // Raised after the fullscreen state has actually changed
    // and needs to be propagated to listeners (UI, icons, etc.)
    public Action<bool> OnFullScreenChanged;
    public void RaiseFullScreenChangeEvent()
    {
        OnFullScreenOptionChanges?.Invoke();
    }
    public void RaiseFullScreenChanged(bool fullscreenMode)
    {
        OnFullScreenChanged?.Invoke(fullscreenMode);
    }
}
