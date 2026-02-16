using UnityEngine;
using UnityEngine.UI;

public class ScpMouseIcon : MonoBehaviour
{
    public RectTransform cursorUI; // arraste sua Image aqui
    [SerializeField] private WingSceneTransition sceneTransitionController;

    private void OnEnable()
    {
        sceneTransitionController.SceneChangeStarted += LockMouse;
    }

    private void OnDisable()
    {
        sceneTransitionController.SceneChangeStarted -= LockMouse;
    }

    private void Start()
    {
        ShowCustomMouse();
    }

    void Update()
    {
        ControlMousePosition();
    }

    private void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
    }

    private void ShowCustomMouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
    }

    private void ControlMousePosition()
    {
        Vector2 mousePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            cursorUI.parent as RectTransform,
            Input.mousePosition,
            null, // ou Camera.main se Canvas não for Overlay
            out mousePos
        );

        cursorUI.localPosition = mousePos;
    }
}
