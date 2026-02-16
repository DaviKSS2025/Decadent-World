using System;

[Serializable]
public class SlotData
{
    public int textIndex = 0;
    public int chapterReached = 1;
    public float totalProgressionOnChapter = 0f;
}

[Serializable]
public class SaveFile
{
    public SlotData[] slots = new SlotData[3]
    {
        new SlotData(),
        new SlotData(),
        new SlotData()
    };

    public int maxUnlockedChapter = 1;
    public int currentAvailableChapters = 1;
}

