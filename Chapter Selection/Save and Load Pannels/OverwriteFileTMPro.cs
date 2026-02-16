using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class OverwriteFileText : MonoBehaviour
{
    [SerializeField] private PannelControlChannel _pannelControlChannel;
    [SerializeField] private LocalizationToggleChannel _localizationChannel;
    private TextMeshProUGUI _text;
    private int _currentLocalization;
    private int _lastSaveSlotIndexClicked;
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        _localizationChannel.ReturnedLocalizationIndex += UpdateCurrentLocalization;
        _pannelControlChannel.ReturnedLastSaveSlotIndex += UpdateLastSaveSlotIndexClicked;
        _localizationChannel.RaiseRequestedLocalizationIndex();
        _pannelControlChannel.RaiseLastSaveSlotIndexRequested();
    }
    private void OnDisable()
    {
        _localizationChannel.ReturnedLocalizationIndex -= UpdateCurrentLocalization;
        _pannelControlChannel.ReturnedLastSaveSlotIndex -= UpdateLastSaveSlotIndexClicked;
    }

    private void UpdateText(int saveSlotIndex)
    {
        if (_currentLocalization == 0)
        {
            _text.text = $"Are you sure you want to overwrite the file #0{_lastSaveSlotIndexClicked + 1}?";
        }
        else
        {
            _text.text = $"Tem certeza de que deseja sobrescrever o arquivo #0{_lastSaveSlotIndexClicked + 1}?";
        }
    }
    private void UpdateLastSaveSlotIndexClicked(int saveSlotIndex)
    {
        _lastSaveSlotIndexClicked = saveSlotIndex;
        UpdateText(saveSlotIndex);
    }
    private void UpdateCurrentLocalization(int localizationIndex)
    {
        _currentLocalization = localizationIndex;
    }
}
