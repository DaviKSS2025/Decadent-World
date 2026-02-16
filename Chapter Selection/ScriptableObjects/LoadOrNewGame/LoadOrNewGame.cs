using UnityEngine;

[CreateAssetMenu(fileName = "LoadOrNewGame", menuName = "Scriptable Objects/LoadOrNewGame")]

public class LoadOrNewGame : ScriptableObject
{
    [SerializeField] private ButtonType _buttonType;
    public ButtonType Type => _buttonType;
}
public enum ButtonType
{
    New,
    Load
}