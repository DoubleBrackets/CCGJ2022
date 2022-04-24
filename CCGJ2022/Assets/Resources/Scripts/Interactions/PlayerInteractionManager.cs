using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerInteractionManager : MonoBehaviour
{
    public SpriteRenderer heldCursor;
    public Sprite defaultCursor;
    public Sprite missingCursor;

    public void Awake()
    {
        var interactables = GameObject.FindObjectsOfType<BaseInteractable>();
        foreach(var interactable in interactables)
        {
            interactable.AssignContext(this);
        }
    }


    public Action<Vector2,BaseInteractable> onInteractDown;
    public Action<Vector2,BaseInteractable> onInteractUp;

    private BaseInteractable heldInteractable;

    public void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetMouseButtonDown(0))
        {
            if(heldInteractable == null)
            {
                Cursor.visible = false;
                onInteractDown?.Invoke(mousePos, heldInteractable);
            }
            else
            {
                onInteractUp?.Invoke(mousePos, heldInteractable);
                heldInteractable = null;
                heldCursor.sprite = defaultCursor;
            }
        }
    }

    public void SetHeldInteractable(BaseInteractable toHold)
    {
        heldInteractable = toHold;
        heldCursor.sprite = toHold.heldSprite != null ? toHold.heldSprite : missingCursor;
    }

    public void LateUpdate()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        heldCursor.transform.position = mousePos;
    }
}
