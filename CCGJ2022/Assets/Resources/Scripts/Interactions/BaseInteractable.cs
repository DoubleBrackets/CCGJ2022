using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInteractable : MonoBehaviour
{
    protected PlayerInteractionManager interactionContext;

    public Collider2D interactionBound;
    public Sprite heldSprite;
    public Material heldSpriteMaterial;

    public void Start()
    {
        AssignContext(PlayerInteractionManager.instance);
    }

    public void AssignContext(PlayerInteractionManager interactionContext)
    {
        this.interactionContext = interactionContext;
        interactionContext.onClickDown += OnClickDownListener;
        interactionContext.onDragMove += OnDragMoveListener;
        interactionContext.onDragRelease += OnDragReleaseListener;
        interactionContext.onSingleInteract += OnSingleInteractListener;
        interactionContext.onMouseMove += OnMouseMoveListener;
    }

    public virtual void OnDestroy()
    {
        interactionContext.onClickDown -= OnClickDownListener;
        interactionContext.onDragMove -= OnDragMoveListener;
        interactionContext.onDragRelease -= OnDragReleaseListener;
        interactionContext.onSingleInteract -= OnSingleInteractListener;
        interactionContext.onMouseMove -= OnMouseMoveListener;
    }

    public bool IsInBounds(Vector2 pos)
    {
        return interactionBound.OverlapPoint(pos);
    }

    public virtual void OnClickDownListener(Vector2 mousePos, BaseInteractable heldInteractable) { }
    public virtual void OnDragMoveListener(Vector2 mousePos, BaseInteractable heldInteractable) { }
    public virtual void OnDragReleaseListener(Vector2 mousePos, BaseInteractable heldInteractable) { }
    public virtual void OnSingleInteractListener(Vector2 mousePos, BaseInteractable heldInteractable) { }
    public virtual void OnMouseMoveListener(Vector2 mousePos, BaseInteractable heldInteractable) { }
}
