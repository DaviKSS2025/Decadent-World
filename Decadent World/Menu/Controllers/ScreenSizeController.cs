using UnityEngine;

// Central controller responsible for screen resolution and fullscreen settings.
// Listens to UI events through channels, applies screen changes,
// persists user preferences, and updates UI state accordingly.
public class ScreenSizeController : MonoBehaviour
{
    // Supported screen resolutions (index-based for UI navigation)
    private Vector2Int[] _resolutionTypes;

    [SerializeField] private ResolutionToggleChannel _resolutionChannel;
    [SerializeField] private FullScreenToggleChannel _fullscreenChannel;

    private void Awake()
    {
        // Initialize supported resolutions and apply saved resolution on startup
        _resolutionTypes = new Vector2Int[]
        {
            new Vector2Int(1280, 720),
            new Vector2Int(1920, 1080),
            new Vector2Int(2560, 1440),
            new Vector2Int(3840, 2160),
        };
        OnResolutionChanging(0);
    }

    private void OnEnable()
    {
        _resolutionChannel.ResolutionChanging += OnResolutionChanging;
        _resolutionChannel.RequestedResolutionValue += OnRequestedResolutionValue;
        _resolutionChannel.RequestedResolutionIndex += OnRequestedResolutionIndex;
        _fullscreenChannel.OnFullScreenOptionChanges += OnFullScreenChanging;
    }

    private void OnDisable()
    {
        _resolutionChannel.ResolutionChanging -= OnResolutionChanging;
        _resolutionChannel.RequestedResolutionValue -= OnRequestedResolutionValue;
        _resolutionChannel.RequestedResolutionIndex -= OnRequestedResolutionIndex;
        _fullscreenChannel.OnFullScreenOptionChanges -= OnFullScreenChanging;
    }

    // Applies a resolution change request coming from UI
    // and updates both screen settings and UI state
    private void OnResolutionChanging(int valueToChangeResolutionArray)
    {
        int resolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", 1) + valueToChangeResolutionArray;

        if (resolutionIndex >= 0 && resolutionIndex <= _resolutionTypes.Length-1)
        {
            Screen.SetResolution(_resolutionTypes[resolutionIndex].x, _resolutionTypes[resolutionIndex].y, Screen.fullScreen);
            PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);
            _resolutionChannel.RaiseResolutionChanged(resolutionIndex, _resolutionTypes.Length);
            OnRequestedResolutionValue();
        }
    }

    // Sends the current resolution values to UI listeners (text labels, icons, etc.)
    private void OnRequestedResolutionValue()
    {
        _resolutionChannel.RaiseUpdateResolutionTexts(_resolutionTypes[PlayerPrefs.GetInt("ResolutionIndex", 1)]);
    }
    // Sends the current resolution index so UI buttons can enable/disable themselves
    private void OnRequestedResolutionIndex()
    {
        _resolutionChannel.RaiseResolutionChanged(PlayerPrefs.GetInt("ResolutionIndex", 1), _resolutionTypes.Length);
    }

    // Toggles fullscreen mode and notifies listeners of the new state
    private void OnFullScreenChanging()
    {
        Screen.fullScreen = !Screen.fullScreen;
        _fullscreenChannel.OnFullScreenChanged(Screen.fullScreen);
    }
}
