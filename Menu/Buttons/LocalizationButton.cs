using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Image))]
public class LocalizationButton : MenuBaseButton
{
    private Button _button;
    private Image _image;

    [SerializeField] private LocalizationToggleChannel _localizationChannel;
    [SerializeField] private int _valueToChangeLocalizationArray;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _localizationChannel.LocalizationChanged += OnLocalizationChanged;
        _localizationChannel.RaiseRequestedLocalizationIndex();
    }
    private void OnDisable()
    {
        _localizationChannel.LocalizationChanged -= OnLocalizationChanged;
    }
    public override void OnClicked()
    {
        base.OnClicked();
        _localizationChannel.RaiseLocalizationChanging(_valueToChangeLocalizationArray);
    }
    // Enables or disables this localization button based on the current localization index.
    // Decrease button is disabled at the minimum resolution,
    // Increase button is disabled at the maximum resolution.
    private void OnLocalizationChanged(int localizationIndex, int localizationSizeNumber)
    {
        if (localizationIndex <= 0 && _valueToChangeLocalizationArray < 0)
        {
            _button.enabled = false;
            _image.enabled = false;
        }
        else if (localizationIndex >= localizationSizeNumber && _valueToChangeLocalizationArray > 0)
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
