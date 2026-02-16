using UnityEngine;

public class ConfirmNewGameButton : MenuBaseButton
{
    [SerializeField] private PannelControlChannel _panelControlChannel;
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
        _panelControlChannel.RaiseNewGameConfirmed();
    }

}
