using UnityEngine;

[CreateAssetMenu(menuName = "Game/Chapter Database")]
public class ChapterDatabase : ScriptableObject
{
    public SaveSlotChapterInfo[] chapters;

    public SaveSlotChapterInfo GetChapter(int index)
    {
        return chapters[index];
    }
}

