using UnityEngine;

public class NewOrLoadGameButton : MenuBaseButton
{
    [SerializeField] private LoadOrNewGame _buttonFunction;
    [SerializeField] private NewGameOrLoadChannel _functionChannel;

    public override void OnMouseHover()
    {
        _audioListener?.RaiseEvent(_hoverSound);
    }
    public override void OnMouseExit()
    {
        _audioListener?.RaiseEvent(_hoverSound);
    }
    public override void OnClicked()
    {
        base.OnClicked();
        _functionChannel.RaiseUpdateLastButtonClicked(_buttonFunction.Type);
    }
}
