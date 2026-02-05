using UnityEngine;
using UnityEngine.Localization.Settings;
using System.Collections;

// Central controller responsible for applying localization changes.
// Listens to localization UI events, persists the selected language,
// and applies the locale through Unity Localization asynchronously.
public class LocalizationController : MonoBehaviour
{
    [SerializeField] private LocalizationToggleChannel _localizationChannel;

    // Number of available localizations (used to clamp UI navigation)
    private int _localizationSizeNumber = 1;

    // Prevents concurrent locale changes
    private bool isChanging;

    private void OnEnable()
    {
        _localizationChannel.LocalizationChanging += OnLocalizationChanging;
        _localizationChannel.RequestedLocalizationIndex += OnRequestedLocalizationIndex;
    }
    private void OnDisable()
    {
        _localizationChannel.LocalizationChanging -= OnLocalizationChanging;
        _localizationChannel.RequestedLocalizationIndex -= OnRequestedLocalizationIndex;
    }

    // Sends the current localization index back to UI listeners (buttons, icons, etc.)
    private void OnRequestedLocalizationIndex()
    {
        _localizationChannel.RaiseLocalizationChanged(PlayerPrefs.GetInt("LocalizationIndex", 0), _localizationSizeNumber);
    }

    // Handles localization change requests coming from UI
    // (e.g. next / previous language buttons)
    private void OnLocalizationChanging(int valueToChangeLocalizationArray)
    {
        int localizationIndex = PlayerPrefs.GetInt("LocalizationIndex", 0) + valueToChangeLocalizationArray;

        if (localizationIndex >= 0 && localizationIndex <= _localizationSizeNumber)
        {
            PlayerPrefs.SetInt("LocalizationIndex", localizationIndex);
            _localizationChannel.RaiseLocalizationChanged(localizationIndex, _localizationSizeNumber);
            SetLanguage(localizationIndex);
        }
    }

    void Start()
    {
        // Apply saved localization on startup
        StartCoroutine(SetLocaleRoutine(PlayerPrefs.GetInt("LocalizationIndex", 0)));
    }


    // Persists localization index and safely triggers locale change
    // while preventing concurrent updates
    private void SetLanguage(int localizationIndex)
    {
        PlayerPrefs.SetInt("LocalizationIndex", localizationIndex);

        if (!isChanging)
            StartCoroutine(SetLocaleRoutine(localizationIndex));
    }


    // Applies the selected locale asynchronously using Unity Localization.
    // Uses a guard flag to avoid multiple locale changes running in parallel.
    IEnumerator SetLocaleRoutine(int localizationIndex)
    {
        isChanging = true;

        var locales = LocalizationSettings.AvailableLocales.Locales;

        if (localizationIndex >= 0 && localizationIndex < locales.Count)
            LocalizationSettings.SelectedLocale = locales[localizationIndex];

        yield return LocalizationSettings.InitializationOperation;
        isChanging = false;
    }
}
