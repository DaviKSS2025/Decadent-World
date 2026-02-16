using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PannelControlChannel", menuName = "Scriptable Objects/PannelControlChannel")]
public class PannelControlChannel : ScriptableObject
{
    public Action ConfirmationPanelClosed;
    public Action NewGameOrLoadPannelClosed;
    public Action<int,int,int> SaveSlotClicked;
    public Action NewGameConfirmed;
    public Action LastSaveSlotIndexRequested;
    public Action<int> ReturnedLastSaveSlotIndex;

    public void RaiseConfirmationPanelClosed()
    {
        ConfirmationPanelClosed?.Invoke();
    }

    public void RaiseNewGameOrLoadPannelClosed()
    {
        NewGameOrLoadPannelClosed?.Invoke();
    }

    public void RaiseSaveSlotClicked(int slotIndex, int dialogueIndex, int chapterIndex)
    {
        SaveSlotClicked?.Invoke(slotIndex, dialogueIndex, chapterIndex);
    }

    public void RaiseNewGameConfirmed()
    {
        NewGameConfirmed?.Invoke();
    }

    public void RaiseLastSaveSlotIndexRequested()
    {
        LastSaveSlotIndexRequested?.Invoke();
    }

    public void RaiseReturnedLastSaveSlotIndex(int slotIndex)
    {
        ReturnedLastSaveSlotIndex.Invoke(slotIndex);
    }
}
