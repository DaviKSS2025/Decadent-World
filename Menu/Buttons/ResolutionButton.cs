using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Image))]
public class ResolutionButton : MenuBaseButton
{
    private Button _button;
    private Image _image;
    [SerializeField] private ResolutionToggleChannel _resolutionChannel;
    [SerializeField] private int _valueToChangeResolutionArray;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
    }
    private void OnEnable()
    {
        _resolutionChannel.ResolutionChanged += OnResolutionChanged;
        _resolutionChannel.RaiseRequestedResolutionIndex();
    }
    private void OnDisable()
    {
        _resolutionChannel.ResolutionChanged -= OnResolutionChanged;
    }
    public override void OnClicked()
    {
        base.OnClicked();
        _resolutionChannel.RaiseResolutionChanging(_valueToChangeResolutionArray);
    }
    // Enables or disables this resolution button based on the current resolution index.
    // Decrease button is disabled at the minimum resolution,
    // Increase button is disabled at the maximum resolution.
    public void OnResolutionChanged(int resolutionIndex, int resolutionArrayLenght)
    {
        if (resolutionIndex <= 0 && _valueToChangeResolutionArray < 0)
        {
            _button.enabled = false;
            _image.enabled = false;
        }
        else if (resolutionIndex >= resolutionArrayLenght-1 && _valueToChangeResolutionArray > 0)
        {
            _button.enabled = false;
            _image.enabled = false;
        }
        else
        {
            _button.enabled = true;
            _image.enabled = true;
        }
    }
}

