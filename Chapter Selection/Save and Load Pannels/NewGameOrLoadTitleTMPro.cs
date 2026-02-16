using TMPro;
using UnityEngine;
[RequireComponent(typeof(TextMeshProUGUI))]
public class NewGameOrLoadTitleTMPro : MonoBehaviour
{
    [SerializeField] private NewGameOrLoadChannel _functionChannel;
    [SerializeField] private LocalizationToggleChannel _localizationChannel;
    private TextMeshProUGUI _text;
    private int _currentLocalization;
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _localizationChannel.ReturnedLocalizationIndex += UpdateCurrentLocalization;
        _localizationChannel.RaiseRequestedLocalizationIndex();
    }
    private void OnEnable()
    {
        _functionChannel.UpdateLastButtonClicked += UpdateTMProText;
        _functionChannel.RaiseAskLastButtonClicked();
    }

    private void OnDisable()
    {
        _localizationChannel.ReturnedLocalizationIndex -= UpdateCurrentLocalization;
        _functionChannel.UpdateLastButtonClicked -= UpdateTMProText;
    }

    private void UpdateTMProText(ButtonType lastButtonClicked)
    {
        if (_currentLocalization == 0)
        {
            if (lastButtonClicked == ButtonType.New)
            {
                _text.text = "New game";
            }
            else
            {
                _text.text = "Load game";
            }
        }
        else
        {
            if (lastButtonClicked == ButtonType.New)
            {
                _text.text = "Novo jogo";
            }
            else
            {
                _text.text = "Carregar jogo";
            }
        }
    }

    private void UpdateCurrentLocalization(int localizationIndex)
    {
        _currentLocalization = localizationIndex;
    }
}
