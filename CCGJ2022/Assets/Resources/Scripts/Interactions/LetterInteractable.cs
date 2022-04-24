using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterInteractable : BaseInteractable
{
    public SpriteRenderer letterRenderer;
    public Sprite openedSprite;
    public Sprite closedSprite;

    public string letterText;
    public bool isInitialRequestLetter;

    private RequestScriptableObject attachedRequest;
    private RequestManager requestManager;

    public override void OnSingleInteractListener(Vector2 mousePos, BaseInteractable heldInteractable)
    {
        if (!IsInBounds(mousePos) || !LetterDisplayManager.instance.TryDisplay(letterText)) return;
        letterRenderer.sprite = openedSprite;
        if(!isInitialRequestLetter)
        {
            Destroy(gameObject);
        }
    }

    public override void OnDragReleaseListener(Vector2 mousePos, BaseInteractable heldInteractable)
    {
        if (!IsInBounds(mousePos) || !isInitialRequestLetter || heldInteractable == null) return;
        if(heldInteractable.GetType() == typeof(CauldronInteractable))
        {
            letterRenderer.sprite = closedSprite;
            requestManager.SubmitPotion(((CauldronInteractable)heldInteractable).GetPotion(),this,attachedRequest);
            print("Submit potion");
            Destroy(gameObject);
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

    public void AssignRequest(RequestManager manager,RequestScriptableObject request,RequestResponse response = null)
    {
        requestManager = manager;
        attachedRequest = request;
        if(isInitialRequestLetter)
        {
            letterText = request.initialRequestText;
        }
        else
        {
            letterText = response.responseText;
        }
    }
}
 