using UnityEngine;

[CreateAssetMenu(fileName = "SaveSlotIndex", menuName = "Scriptable Objects/SaveSlotIndex")]
public class SaveSlotIndex : ScriptableObject
{
    [SerializeField] private int _slotIndex;

    public int SlotIndex
    {
        get => _slotIndex;
    }
}
