using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CloseGameButton : MenuBaseButton
{
    public override void OnClicked()
    {
        base.OnClicked();
        Application.Quit();
    }
}
