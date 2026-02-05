using UnityEngine;

/// <summary>
/// Base class for menu buttons.
/// Handles common audio feedback and animation triggers.
/// Child classes may override behavior as needed.
/// </summary>

public abstract class MenuBaseButton : MonoBehaviour, IMenuButton
{
    [SerializeField] protected AudioEventChannel _audioListener;
    [SerializeField] protected SimpleAudioEvent _hoverSound;
    [SerializeField] protected SimpleAudioEvent _clickSound;

    protected Animator _animator;

    // Cached animator parameter hashes to avoid string lookups at runtime
    protected static readonly int Playing = Animator.StringToHash("Playing");
    protected static readonly int Idle = Animator.StringToHash("Idle");

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public virtual void OnMouseHover()
    {
        _audioListener?.RaiseEvent(_hoverSound);
        _animator.SetTrigger(Playing);
    }
    public virtual void OnMouseExit()
    {
        _audioListener?.RaiseEvent(_hoverSound);
        _animator.SetTrigger(Idle);
    }
    public virtual void OnClicked()
    {
        _audioListener?.RaiseEvent(_clickSound);
    }
}
