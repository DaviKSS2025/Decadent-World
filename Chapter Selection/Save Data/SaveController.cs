using System;
using UnityEngine;

/// Interface for manipulating save slot data.
/// Provides controlled access to SaveManager data while
/// notifying listeners when slot or progression changes.
/// 
/// Acts as a bridge between gameplay systems/UI and persistence.

public class SaveController : MonoBehaviour
{
    public static SaveController Instance;

    // Fired whenever a slot's data is modified
    public event Action<int, SlotData> OnSlotUpdated;
    // Fired when global chapter progression changes
    public event Action<int> OnMaxChapterChanged;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public SlotData GetSlot(int index)
    {
        return SaveManager.Instance.Data.slots[index];
    }
    // Updates dialogue index for slot and persists change
    public void SetTextIndex(int slot, int value)
    {
        var data = SaveManager.Instance.Data.slots[slot];
        data.textIndex = value;

        SaveManager.Instance.Save();
        OnSlotUpdated?.Invoke(slot, data);
    }
    // Updates highest chapter reached for slot
    public void SetChapterReached(int slot, int chapter)
    {
        var data = SaveManager.Instance.Data.slots[slot];
        data.chapterReached = chapter;

        SaveManager.Instance.Save();
        OnSlotUpdated?.Invoke(slot, data);
    }
    // Updates global progression limit
    public void SetMaxChapter(int chapter)
    {
        SaveManager.Instance.Data.maxUnlockedChapter = chapter;

        SaveManager.Instance.Save();
        OnMaxChapterChanged?.Invoke(chapter);
    }
}
