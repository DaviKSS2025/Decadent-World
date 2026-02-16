using UnityEngine;
using System;

// Event channel responsible for decoupling scene change UI logic
// from the system that applies scene changes.
[CreateAssetMenu(fileName = "SceneChangeListener", menuName = "Scriptable Objects/SceneChangeListener")]
public class SceneChangeListener : ScriptableObject
{
    // Raised when localization change is requested (e.g. UI button pressed)
    // and repass the target scene name
    public Action<string> SceneChanged;

    // Raised when the scene transition cutscene starts
    // and needs to interrupt listeners systems (UI, icons, etc.)
    public Action SceneTransitionsStarted;

    public Action<int,int> UpdatedVisualNovelTextIndexToGo;

    public void RaiseSceneChanged(string nextSceneName)
    {
        SceneChanged?.Invoke(nextSceneName);
    }

    public void RaiseTransitionsStarted()
    {
        SceneTransitionsStarted?.Invoke();
    }

    public void RaiseUpdatedVisualNovelTextIndexToGo(int dialogueIndex, int chapterIndex)
    {
        UpdatedVisualNovelTextIndexToGo?.Invoke(dialogueIndex, chapterIndex);
    }
}
