using TMPro;
using UnityEngine;

[RequireComponent (typeof(TextMeshProUGUI))]
public class ChapterNamesTMPro : MonoBehaviour
{
    private TextMeshProUGUI _text;
    [SerializeField] private ChapterIndex _chapterIndex;
    [SerializeField] private ChapterNames _chapterName;
    [SerializeField] private LocalizationToggleChannel _localizationChannel;
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        _localizationChannel.ReturnedLocalizationIndex += UpdateTextIfChapterIsUnlocked;
    }
    private void OnDisable()
    {
        _localizationChannel.ReturnedLocalizationIndex -= UpdateTextIfChapterIsUnlocked;
    }
    private void Start()
    {
        _localizationChannel.RequestedLocalizationIndex();
    }
    private void UpdateTextIfChapterIsUnlocked(int localizationIndex)
    {
        int unlocked = SaveManager.Instance.Data.maxUnlockedChapter;

        if (_chapterIndex.ChapterIndexNumber <= unlocked)
        {
            switch (localizationIndex)
            {
                case 0:
                    _text.text = _chapterName.ChapterNameEN;
                    break;
                default:
                    _text.text = _chapterName.ChapterNamePT;
                    break;
            }
        }
        else
        {
            switch (localizationIndex)
            {
                case 0:
                    _text.text = $"Chapter {_chapterIndex.ChapterIndexNumber}: Blocked";
                    break;
                default:
                    _text.text = $"Capítulo {_chapterIndex.ChapterIndexNumber}: Bloqueado";
                    break;
            }
        }
    }
}
