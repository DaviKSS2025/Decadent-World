using System;
using UnityEngine;
// Event channel responsible for decoupling resolution UI controls
// from the system that applies resolution changes.
[CreateAssetMenu(fileName = "ResolutionToggleChannel", menuName = "Scriptable Objects/ResolutionToggleChannel")]
public class ResolutionToggleChannel : ScriptableObject
{
    // Raised when resolution change is requested (e.g. UI button pressed)
    public Action<int> ResolutionChanging;

    // Raised after the resolution has actually changed
    // and needs to be propagated to listeners (UI, icons, etc.)
    public Action<int, int> ResolutionChanged;
    public Action<Vector2Int> UpdateResolutionTexts;

    // Used by UI elements to query the current resolution index
    // in order to enable or disable navigation buttons
    public Action RequestedResolutionValue;
    public Action RequestedResolutionIndex;
    public void RaiseResolutionChanging(int valueToChangeResolutionArray)
    {
        ResolutionChanging?.Invoke(valueToChangeResolutionArray);
    }
    public void RaiseResolutionChanged(int resolutionIndex, int resolutionArrayLenght)
    {
        ResolutionChanged?.Invoke(resolutionIndex, resolutionArrayLenght);
    }
    public void RaiseUpdateResolutionTexts(Vector2Int resolution)
    {
        UpdateResolutionTexts?.Invoke(resolution);
    }
    public void RaiseRequestedResolutionValue()
    {
        RequestedResolutionValue?.Invoke();
    }
    public void RaiseRequestedResolutionIndex()
    {
        RequestedResolutionIndex?.Invoke();
    }
}
