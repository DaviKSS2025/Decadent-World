using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "ChapterSprite", menuName = "Scriptable Objects/ChapterSprite")]
public class ChapterSprite : ScriptableObject
{
    [SerializeField] private Sprite _unlockedSprite;

    public Sprite UnlockedSprite
    {
        get => _unlockedSprite;
    }
}
