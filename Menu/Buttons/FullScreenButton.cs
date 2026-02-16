using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FullScreenButton : MenuBaseButton
{
    private Image _image;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private FullScreenToggleChannel _fullscreenChannel;
    private void Awake()
    {
        _image = GetComponent<Image>();
    }
    private void OnEnable()
    {
        _fullscreenChannel.OnFullScreenChanged += UpdateSpriteWhenFullscreenModeChanges;
    }
    private void OnDisable()
    {
        _fullscreenChannel.OnFullScreenChanged += UpdateSpriteWhenFullscreenModeChanges;
    }
    public override void OnMouseHover()
    {
        _audioListener?.RaiseEvent(_hoverSound);
        _image.sprite = Screen.fullScreen ? _sprites[3] : _sprites[1];
    }
    public override void OnMouseExit()
    {
        _audioListener?.RaiseEvent(_hoverSound);
        _image.sprite = Screen.fullScreen ? _sprites[2] : _sprites[0];
    }
    public void UpdateSpriteWhenFullscreenModeChanges(bool fullScreenMode)
    {
        _image.sprite = Screen.fullScreen ? _sprites[3] : _sprites[1];
    }
}
