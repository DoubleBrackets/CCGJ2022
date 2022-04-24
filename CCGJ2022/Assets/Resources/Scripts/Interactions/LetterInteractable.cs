using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterInteractable : BaseInteractable
{
    public SpriteRenderer letterRenderer;
    public Sprite openedSprite;
    public Sprite closedSprite;
    public Sprite filledSprite;

    public string letterText;
    public bool isInitialRequestLetter;
    private bool opened = false;

    public bool Opened
    {
        get => opened; 
    }


    private RequestScriptableObject attachedRequest;

    public RequestScriptableObject AttachedRequest
    {
        get => attachedRequest;
    }

    private RequestManager requestManager;

    private RequestResponse heldResponse = null;
    public RequestResponse HeldResponse
    {
        get => heldResponse;
    }

    public override void OnSingleInteractListener(Vector2 mousePos, BaseInteractable heldInteractable)
    {
        if (!IsInBounds(mousePos) || !LetterDisplayManager.instance.TryDisplay(letterText) || heldResponse != null) return;
        letterRenderer.sprite = openedSprite;
        opened = true;
    }

    public override void OnDragReleaseListener(Vector2 mousePos, BaseInteractable heldInteractable)
    {
        if (!IsInBounds(mousePos) ||
            !isInitialRequestLetter ||
            interactionContext.HeldInteractable == null ||
            !opened ||
            heldResponse != null) return;

        if (heldInteractable.GetType() == typeof(CauldronInteractable))
        {
            letterRenderer.sprite = closedSprite;
            heldResponse = attachedRequest.EvaluatePotion(((CauldronInteractable)heldInteractable).GetPotion());
            interactionContext.ClearHeldInteractable();
            letterRenderer.sprite = filledSprite;
        }
    }
    public override void OnClickDownListener(Vector2 mousePos, BaseInteractable heldInteractable)
    {
        if (!IsInBounds(mousePos)) return;
        interactionContext.SetHeldInteractable(this);
    }

    public override void OnDragMoveListener(Vector2 mousePos, BaseInteractable heldInteractable)
    {
        if (heldInteractable != this) return;
        transform.position = mousePos;
    }

    public void AssignRequest(RequestManager manager, RequestScriptableObject request, RequestResponse response = null)
    {
        requestManager = manager;
        attachedRequest = request;
        if (isInitialRequestLetter)
        {
            letterText = request.initialRequestText;
        }
        else
        {
            letterText = response.responseText;
        }
    }
}

