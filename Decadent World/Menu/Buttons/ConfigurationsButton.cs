using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ConfigurationsButton : MenuBaseButton
{
    private int _maxRotationSpeed = 5;
    private int _currentRotationSpeed;
    private int _rotationSide;
    private float _scaleMultiplierWhenMouseOn = 1.2f;
    private Vector2 _initialScale = new Vector2(1,1);
    [SerializeField] private GameObject _configurationsPanel; 
    public override void OnMouseHover()
    {
        _audioListener?.RaiseEvent(_hoverSound);
        SpriteGrowWhenMouseHover();
    }
    public override void OnMouseExit()
    {
        base.OnMouseExit();
        SpriteShrinkWhenMouseExit();
    }
    public override void OnClicked()
    {
        base.OnClicked();
        ToggleConfigurationsPanel();
        _animator.SetTrigger(Playing);
    }
    private void Update()
    {
        RotateSprite();
    }
    private void SpriteGrowWhenMouseHover()
    {
        transform.localScale *= _scaleMultiplierWhenMouseOn;
        _currentRotationSpeed = _maxRotationSpeed;
        _rotationSide = Random.value < 0.5f ? 1 : -1;
    }
    private void SpriteShrinkWhenMouseExit()
    {
        transform.localScale = _initialScale;
        _currentRotationSpeed = 0;
    }
    private void RotateSprite()
    {
        transform.Rotate(0f, 0f, _currentRotationSpeed * _rotationSide * Time.deltaTime);
    }
    private void ToggleConfigurationsPanel()
    {
        _configurationsPanel.SetActive(!_configurationsPanel.activeInHierarchy);
    }
}
