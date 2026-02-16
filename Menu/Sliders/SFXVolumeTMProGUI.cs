using TMPro;
using UnityEngine;

// Updates a TMP text element to reflect the current SFX volume percentage.
[RequireComponent(typeof(TextMeshProUGUI))]
public class SFXVolumeTMProGUI : MonoBehaviour
{
    [SerializeField] private SFXVolumeChannel _SFXVolumeChannel;
    private TextMeshProUGUI _TMPro;

    private void Awake()
    {
        _TMPro = GetComponent<TextMeshProUGUI>();
        UpdateTMProText(PlayerPrefs.GetFloat("SFXVolume", 0.5f));
    }
    private void OnEnable()
    {
        _SFXVolumeChannel.OnSFXVolumeChanged += UpdateTMProText;
    }
    private void OnDisable()
    {
        _SFXVolumeChannel.OnSFXVolumeChanged -= UpdateTMProText;
    }
    private void UpdateTMProText(float volume)
    {
        _TMPro.text = TranslateVolumeToTextPercentage(volume);
    }
    private string TranslateVolumeToTextPercentage(float volume)
    {
        return (volume * 100).ToString("F0") + "%";
    }
}
