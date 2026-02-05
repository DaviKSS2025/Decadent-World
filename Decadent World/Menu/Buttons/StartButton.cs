using UnityEngine;

[RequireComponent(typeof(Animator))]
public class StartButton : MenuBaseButton
{
    [SerializeField] private SceneToGo _sceneName;
    [SerializeField] private SceneChangeListener _sceneChangeListener;

    private static readonly int Clicked = Animator.StringToHash("Clicked");
    public override void OnMouseHover()
    {
        base.OnMouseHover();
    }
    public override void OnMouseExit()
    {
        base.OnMouseExit();
    }
    public override void OnClicked()
    {
        base.OnClicked();
        _animator.SetTrigger(Clicked);
    }
    public void OnClickAnimationEnd()
    {
        _sceneChangeListener.RaiseSceneChanged(_sceneName.SceneName);
        _sceneChangeListener.RaiseTransitionsStarted();
    }
}
