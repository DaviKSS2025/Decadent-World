using UnityEngine;

[CreateAssetMenu(fileName = "ChapterNames", menuName = "Scriptable Objects/ChapterNames")]
public class ChapterNames : ScriptableObject
{
    [SerializeField] private string _chapterNamePT;
    [SerializeField] private string _chapterNameEN;

    public string ChapterNamePT
    {
        get => _chapterNamePT;
    }
    public string ChapterNameEN
    {
        get => _chapterNameEN;
    }
}
