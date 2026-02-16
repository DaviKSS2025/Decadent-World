using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class SaveSlotTMPro : MonoBehaviour
{
    private TextMeshProUGUI _text;
    [SerializeField] private SaveSlotIndex _saveSlotIndex;
    [SerializeField] private LocalizationToggleChannel _localizationChannel;
    [SerializeField] private ChapterDatabase _chapterDatabase;
    private int _progressionPercentage;
    private int _currentChapter;
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();

        _progressionPercentage = (int) SaveManager.Instance.Data.slots[_saveSlotIndex.SlotIndex].totalProgressionOnChapter;
        _currentChapter = SaveManager.Instance.Data.slots[_saveSlotIndex.SlotIndex].chapterReached;
    }
    private void OnEnable()
    {
        _localizationChannel.ReturnedLocalizationIndex += UpdateText;
        _localizationChannel.RaiseRequestedLocalizationIndex();
    }
    private void OnDisable()
    {
        _localizationChannel.ReturnedLocalizationIndex -= UpdateText;
    }
    private void UpdateText(int localizationIndex)
    {
        if (localizationIndex == 0)
        {
            string chapterName = _chapterDatabase.GetChapter(_currentChapter-1).ChapterNames.ChapterNameEN;

            if (_saveSlotIndex.SlotIndex == 0)
            {
                _text.text = $"#{_saveSlotIndex.SlotIndex+1} Quick save\nTotal progress: {_progressionPercentage}%\n{chapterName}";
            }
            else
            {
                _text.text = $"#{_saveSlotIndex.SlotIndex+1} Manual save\nTotal progress: {_progressionPercentage}%\n{chapterName}";
            }
        }
        else
        {
            string chapterName = _chapterDatabase.GetChapter(_currentChapter-1).ChapterNames.ChapterNamePT;

            if (_saveSlotIndex.SlotIndex == 0)
            {
                _text.text = $"#{_saveSlotIndex.SlotIndex+1} Salvamento rápido\nProgressão total: {_progressionPercentage}%\n{chapterName}";
            }
            else
            {
                _text.text = $"#{_saveSlotIndex.SlotIndex+1} Salvamento manual\nProgressão total: {_progressionPercentage}%\n{chapterName}";
            }
        }
    }
}
