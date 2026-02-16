using UnityEngine;

[CreateAssetMenu(fileName = "ChapterIndex", menuName = "Scriptable Objects/ChapterIndex")]
public class ChapterIndex : ScriptableObject
{
    [SerializeField] private int _chapterIndex;

    public int ChapterIndexNumber
    {
        get => _chapterIndex;
    }
}
