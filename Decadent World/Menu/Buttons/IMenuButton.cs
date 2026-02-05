using UnityEngine;
using UnityEngine.EventSystems;

public interface IMenuButton
{
    void OnMouseHover();

    void OnMouseExit();

    void OnClicked();
}
