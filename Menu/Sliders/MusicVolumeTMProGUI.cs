using TMPro;
using UnityEngine;

// Updates a TMP text element to reflect the current music volume percentage.
[RequireComponent(typeof(TextMeshProUGUI))]
public class MusicVolumeTMProGUI : MonoBehaviour
{
    [SerializeField] private MusicVolumeChannel _MusicVolumeChannel;
    private TextMeshProUGUI _TMPro;

    private void Awake()
    {
        _TMPro = GetComponent<TextMeshProUGUI>();
        UpdateTMProText(PlayerPrefs.GetFloat("SFXVolume", 0.5f));
    }
    private void OnEnable()
    {
        _MusicVolumeChannel.OnMusicVolumeChanged += UpdateTMProText;
    }
    private void OnDisable()
    {
        _MusicVolumeChannel.OnMusicVolumeChanged -= UpdateTMProText;
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
