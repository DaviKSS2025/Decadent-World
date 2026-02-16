using System;
using UnityEngine;
using UnityEngine.SceneManagement;


// Handles the visual and audio transition between scenes using the wing animation.
// Listens for scene change requests via a channel, plays the transition animation,
// triggers SFX, and loads the target scene when the animation finishes.
[RequireComponent (typeof(Animator))]
public class WingSceneTransition : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private SceneChangeListener _sceneChannel; // Receives scene change requests
    private string _sceneToGo;
    public Action SceneChangeStarted;
    [SerializeField] private AudioEventChannel _audioChannel;
    [SerializeField] private SimpleAudioEvent _wingSound;

    private static readonly int Playing = Animator.StringToHash("Playing");


    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _sceneChannel.SceneChanged += StartSceneChangeTransition;
        _sceneChannel.UpdatedVisualNovelTextIndexToGo += UpdateVisualNovelIndexToGo;
    }

    private void OnDisable()
    {
        _sceneChannel.SceneChanged -= StartSceneChangeTransition;
    }

    // Called when a scene change is requested.
    // Stores the target scene, notifies listeners that the transition started,
    // and begins the wing transition animation.
    private void StartSceneChangeTransition(string sceneToGo)
    {
        _sceneToGo = sceneToGo;
        SceneChangeStarted?.Invoke();
        PlayWingTransitionAnimation();
    }

    // Plays the wing transition animation and its associated sound effect
    private void PlayWingTransitionAnimation()
    {
        _animator.SetTrigger(Playing);
        PlayWingSFX();
    }

    // Called via animation event at the end of the wing transition animation
    // Loads the target scene after the transition completes
    public void OnWingAnimationEnd()
    {
       SceneManager.LoadScene(_sceneToGo);
    }
    public void PlayWingSFX()
    {
        _audioChannel.RaiseEvent(_wingSound);
    }

    private void UpdateVisualNovelIndexToGo(int dialogueIndex, int chapterIndex)
    {
        PlayerPrefs.SetInt("DialogueIndex", dialogueIndex);
        PlayerPrefs.SetInt("CurrentChapter", chapterIndex);
    }
}
