using System;
using UnityEngine;

// Event channel responsible for decoupling localization UI controls
// from the system that applies localization changes.
[CreateAssetMenu(fileName = "LocalizationToggleChannel", menuName = "Scriptable Objects/LocalizationToggleChannel")]
public class LocalizationToggleChannel : ScriptableObject
{
    // Raised when localization change is requested (e.g. UI button pressed)
    public Action<int> LocalizationChanging;

    // Raised after the localization has actually changed
    // and needs to be propagated to listeners (UI, icons, etc.)
    public Action<int, int> LocalizationChanged;
    // Used by UI elements to query the current localization index
    // in order to enable or disable navigation buttons
    public Action RequestedLocalizationIndex;

    public Action<int> ReturnedLocalizationIndex;
    public void RaiseLocalizationChanging(int valueToChangeLocalization)
    {
        LocalizationChanging?.Invoke(valueToChangeLocalization);
    }
    public void RaiseLocalizationChanged(int localizationIndex, int localizationSizeNumber)
    {
        LocalizationChanged?.Invoke(localizationIndex, localizationSizeNumber);
        ReturnedLocalizationIndex?.Invoke(localizationIndex);
    }
    public void RaiseRequestedLocalizationIndex()
    {
        RequestedLocalizationIndex?.Invoke();
    }
}
