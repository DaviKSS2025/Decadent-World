using TMPro;
using UnityEngine;

public class ResolutionTMPro : MonoBehaviour
{
    [SerializeField] private ResolutionToggleChannel _resolutionChannel;
    private TextMeshProUGUI _text;
    void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _resolutionChannel.UpdateResolutionTexts += OnUpdateResolutionTexts;
        _resolutionChannel.RaiseRequestedResolutionValue();
    }
    private void OnDisable()
    {
        _resolutionChannel.UpdateResolutionTexts -= OnUpdateResolutionTexts;
    }

    private void OnUpdateResolutionTexts(Vector2Int resolution)
    {
        _text.text = $"{resolution.x} X {resolution.y}";
    }
}
