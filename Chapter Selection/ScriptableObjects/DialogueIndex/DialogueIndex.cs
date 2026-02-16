using UnityEngine;

[CreateAssetMenu(fileName = "DialogueIndex", menuName = "Scriptable Objects/DialogueIndex")]
public class DialogueIndex : ScriptableObject
{
    [SerializeField] private int _dialogueIndex;

    public int DialogueIndexNumber
    {
        get => _dialogueIndex;
    }
}
