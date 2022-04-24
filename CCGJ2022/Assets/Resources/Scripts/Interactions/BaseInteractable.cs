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
        interactionContext.onInteractDown += OnInteractDownListener;
        interactionContext.onInteractUp += OnInteractUpListener;
        interactionContext.onMouseMove += OnInteractMouseMove;
    }

    public virtual void OnDestroy()
    {
        interactionContext.onInteractDown -= OnInteractDownListener;
        interactionContext.onInteractUp -= OnInteractUpListener;
        interactionContext.onMouseMove -= OnInteractMouseMove;
    }

    public bool IsInBounds(Vector2 pos)
    {
        return interactionBound.OverlapPoint(pos);
    }

    public abstract void OnInteractDownListener(Vector2 mousePos, BaseInteractable heldInteractable);
    public abstract void OnInteractUpListener(Vector2 mousePos, BaseInteractable heldInteractable);

    public virtual void OnInteractMouseMove(Vector2 mouesPos) { }
}
