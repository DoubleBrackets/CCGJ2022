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

    public override void OnInteractDownListener(Vector2 mousePos, BaseInteractable heldInteractable)
    {
        print(letterText);
        letterRenderer.sprite = openedSprite;
        if(!isInitialRequestLetter)
        {
            Destroy(gameObject);
        }
    }

    public override void OnInteractUpListener(Vector2 mousePos, BaseInteractable heldInteractable)
    {
        if (!IsInBounds(mousePos) || !isInitialRequestLetter) return;
        if(heldInteractable.GetType() == typeof(CauldronInteractable))
        {
            letterRenderer.sprite = closedSprite;
            requestManager.SubmitPotion(((CauldronInteractable)heldInteractable).GetPotion(),this,attachedRequest);
            print("Submit potion");
            Destroy(gameObject);
        }
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
 