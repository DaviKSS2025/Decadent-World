using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Base class for menu sliders.
/// Handles common audio feedback and animation triggers.
/// Child classes may override behavior as needed.
/// </summary>
public abstract class MenuBaseSlider : MonoBehaviour, IMenuButton
{
    [SerializeField] protected AudioEventChannel _audioListener;
    [SerializeField] protected SimpleAudioEvent _hoverSound;
    [SerializeField] protected SimpleAudioEvent _clickSound;
    [SerializeField] protected Color _highlightedColor;
    protected Slider _slider;
    protected Selectable _selectable;

    public void Awake()
    {
        _slider = GetComponent<Slider>();
        _selectable = GetComponent<Selectable>();
        _slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
    }
    public virtual void OnMouseHover()
    {
        _audioListener?.RaiseEvent(_hoverSound);
        _slider.image.color = _highlightedColor;
    }
    public virtual void OnMouseExit()
    {
        _audioListener?.RaiseEvent(_hoverSound);
        _slider.image.color = Color.white;
    }
    public virtual void OnClicked()
    {
        _audioListener?.RaiseEvent(_clickSound);
    }
}
