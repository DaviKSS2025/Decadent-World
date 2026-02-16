using UnityEngine;

public class SaveSlotButton : MenuBaseButton
{
    [SerializeField] private PannelControlChannel _pannelControlChannel;
    [SerializeField] private SaveSlotIndex _saveSlotIndex;
    private int _dialogueIndex;
    private int _chapterIndex;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _dialogueIndex = SaveManager.Instance.Data.slots[_saveSlotIndex.SlotIndex].textIndex;
        _chapterIndex = SaveManager.Instance.Data.slots[_saveSlotIndex.SlotIndex].chapterReached;
    }
    public override void OnClicked()
    {
        base.OnClicked();
        _pannelControlChannel.RaiseSaveSlotClicked(_saveSlotIndex.SlotIndex, _dialogueIndex, _chapterIndex);
    }
}
