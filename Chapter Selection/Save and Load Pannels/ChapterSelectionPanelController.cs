using UnityEngine;

public class ChapterSelectionPanelController : MonoBehaviour
{
    /// Controls the chapter selection workflow:
    /// - Opens the New Game / Load panel
    /// - Handles save slot selection
    /// - Displays confirmation when starting a new game
    /// - Clears save data when confirmed
    /// - Triggers scene transition to the visual novel
    ///
    /// This acts as an orchestrator between UI panels and gameplay flow
    /// through event channels.

    [SerializeField] private GameObject _newGameOrLoadPannel;
    [SerializeField] private GameObject _newGameConfirmationPanel;
    [SerializeField] private NewGameOrLoadChannel _newGameOrLoadChannel;
    [SerializeField] private PannelControlChannel _pannelControlChannel;
    [SerializeField] private SceneChangeListener _sceneChangerChannel;
    [SerializeField] private SceneToGo _visualNovelScene;

    // Stores which function triggered the panel (New or Load)
    private ButtonType _lastButtonFunctionClicked;

    // Keeps track of selected save slot across confirmation flow
    private int _lastSaveSlotClicked;

    // Subscribe to UI workflow events
    private void OnEnable()
    {
        _newGameOrLoadChannel.UpdateLastButtonClicked += UpdatePannel;
        _newGameOrLoadChannel.AskLastButtonClicked += OnLastButtonFunctionRequested;
        _pannelControlChannel.ConfirmationPanelClosed += OnConfirmationPanelClosed;
        _pannelControlChannel.NewGameOrLoadPannelClosed += OnNewGameOrLoadPannelClosed;
        _pannelControlChannel.SaveSlotClicked += OnSaveSlotClicked;
        _pannelControlChannel.NewGameConfirmed += OnNewGameConfirmedClearSaveSlot;
        _pannelControlChannel.LastSaveSlotIndexRequested += OnLastSaveSlotIndexRequested;
    }

    // Unsubscribe to prevent memory leaks
    private void OnDisable()
    {
        _newGameOrLoadChannel.UpdateLastButtonClicked -= UpdatePannel;
        _newGameOrLoadChannel.AskLastButtonClicked -= OnLastButtonFunctionRequested;
        _pannelControlChannel.ConfirmationPanelClosed -= OnConfirmationPanelClosed;
        _pannelControlChannel.NewGameOrLoadPannelClosed -= OnNewGameOrLoadPannelClosed;
        _pannelControlChannel.SaveSlotClicked -= OnSaveSlotClicked;
        _pannelControlChannel.NewGameConfirmed -= OnNewGameConfirmedClearSaveSlot;
        _pannelControlChannel.LastSaveSlotIndexRequested -= OnLastSaveSlotIndexRequested;
    }

    private void UpdatePannel(ButtonType buttonFunction)
    {
        _lastButtonFunctionClicked = buttonFunction;
        _newGameOrLoadPannel.SetActive(true);
    }

    private void OnLastButtonFunctionRequested()
    {
        _newGameOrLoadChannel.RaiseUpdateLastButtonClicked(_lastButtonFunctionClicked);
    }

    private void OnNewGameOrLoadPannelClosed()
    {
        _newGameOrLoadPannel.SetActive(false);
    }

    private void OnConfirmationPanelClosed()
    {
        _newGameConfirmationPanel.SetActive(false);
    }


    // If starting a new game, show confirmation
    // Otherwise load directly and transition scene
    private void OnSaveSlotClicked(int slotIndex, int dialogueIndex, int chapterIndex)
    {
        _lastSaveSlotClicked = slotIndex;

        if (_lastButtonFunctionClicked == ButtonType.New)
        {
            _newGameConfirmationPanel.SetActive(true);
        }
        else
        {
            _sceneChangerChannel.RaiseUpdatedVisualNovelTextIndexToGo(dialogueIndex, chapterIndex);
            CallSceneChange();
        }
    }

    // Resets selected save slot progress before starting new game
    // and transitions to beginning of narrative
    private void OnNewGameConfirmedClearSaveSlot()
    {
        SaveController.Instance.SetTextIndex(_lastSaveSlotClicked, 0);
        SaveController.Instance.SetChapterReached(_lastSaveSlotClicked, 1);
        _sceneChangerChannel.RaiseUpdatedVisualNovelTextIndexToGo(0, 1);
        CallSceneChange();
    }

    // Triggers scene transition through channel
    private void CallSceneChange()
    {
        _sceneChangerChannel.SceneChanged(_visualNovelScene.SceneName);
    }

    // Provides last selected slot index to listeners (UI text, etc.)
    private void OnLastSaveSlotIndexRequested()
    {
        _pannelControlChannel.RaiseReturnedLastSaveSlotIndex(_lastSaveSlotClicked);
    }
}
