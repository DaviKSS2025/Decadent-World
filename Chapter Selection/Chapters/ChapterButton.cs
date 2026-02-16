using UnityEngine;
using UnityEngine.UI;
[RequireComponent (typeof(Animator))]
[RequireComponent(typeof(Image))]
public class ChapterButton : MenuBaseButton
{
    [SerializeField] private SceneChangeListener _sceneChannel;
    [SerializeField] private SceneToGo _sceneToGo;
    [SerializeField] private DialogueIndex _dialogueIndex;
    [SerializeField] private ChapterSprite _chapterSprite;
    [SerializeField] private ChapterIndex _chapterIndex;
    private Image _image;
    private Button _button;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        UpdateVisualIfChapterIsUnlocked();
    }
    public override void OnClicked()
    {
        base.OnClicked();
        SetVisualNovelSceneTextIndex();
        _sceneChannel.RaiseSceneChanged(_sceneToGo.SceneName);
    }

    private void UpdateVisualIfChapterIsUnlocked()
    {
        int unlocked = SaveManager.Instance.Data.maxUnlockedChapter;
        int availableChapters = SaveManager.Instance.Data.currentAvailableChapters;
        if (_chapterIndex.ChapterIndexNumber <= unlocked && _chapterIndex.ChapterIndexNumber <= availableChapters)
        {
            _image.sprite = _chapterSprite.UnlockedSprite;
        }
        else
        {
            _button.enabled = false;
        }
    }

    private void SetVisualNovelSceneTextIndex()
    {
        _sceneChannel.RaiseUpdatedVisualNovelTextIndexToGo(_dialogueIndex.DialogueIndexNumber, _chapterIndex.ChapterIndexNumber);
    }


}
