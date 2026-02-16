using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Image))]
public class SaveSlotSprite : MonoBehaviour
{
    [SerializeField] private ChapterDatabase _chapterDatabase;
    [SerializeField] private SaveSlotIndex _slotIndex;
    private Image _image;
    private int _chapterIndex;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _chapterIndex = SaveManager.Instance.Data.slots[_slotIndex.SlotIndex].chapterReached - 1;
        _image.sprite = _chapterDatabase.GetChapter(_chapterIndex).ChapterSprite;
    }
}
