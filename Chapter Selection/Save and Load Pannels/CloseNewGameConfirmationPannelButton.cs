using UnityEngine;

public class CloseNewGameConfirmationPannelButton : MenuBaseButton
{
    [SerializeField] private PannelControlChannel _pannelControlChannel;

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
        _pannelControlChannel.RaiseConfirmationPanelClosed();
    }
}
