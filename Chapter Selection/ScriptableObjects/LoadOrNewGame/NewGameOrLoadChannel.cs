using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGameOrLoadChannel", menuName = "Scriptable Objects/NewGameOrLoadChannel")]
public class NewGameOrLoadChannel : ScriptableObject
{
    public Action<ButtonType> UpdateLastButtonClicked;
    public Action AskLastButtonClicked;

    public void RaiseUpdateLastButtonClicked(ButtonType lastButtonClicked)
    {
        UpdateLastButtonClicked?.Invoke(lastButtonClicked);
    }

    public void RaiseAskLastButtonClicked()
    {
        AskLastButtonClicked?.Invoke();
    }
}
