using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerInteractionManager : MonoBehaviour
{
    public static PlayerInteractionManager instance;
    public SpriteRenderer heldCursor;
    public Sprite defaultCursor;
    public Sprite missingCursor;
    public Material defaultCursorMaterial;

    public void Awake()
    {
        instance = this;
        Cursor.visible = false;
    }


    public Action<Vector2,BaseInteractable> onSingleInteract;
    public Action<Vector2, BaseInteractable> onClickDown;
    public Action<Vector2,BaseInteractable> onDragRelease;
    public Action<Vector2,BaseInteractable> onDragMove;

    private BaseInteractable heldInteractable;
    private Vector2 startPos;
    private bool isDragging = false;
    private bool mouseDown = false;

    public void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetMouseButtonDown(0) && !mouseDown)
        {
            Cursor.visible = false;
            startPos = mousePos;
            mouseDown = true;
            onClickDown?.Invoke(mousePos, heldInteractable);
        }
        if(Input.GetMouseButtonUp(0) && mouseDown)
        {
            mouseDown = false;
            if (isDragging)
            {
                onDragRelease?.Invoke(mousePos,heldInteractable);
                ClearHeldInteractable();
            }
            else
            {
                onSingleInteract?.Invoke(mousePos,heldInteractable);
                ClearHeldInteractable();
            }
            isDragging = false;
        }
        if(!isDragging && mouseDown)
        {
            if((mousePos - startPos).magnitude > 0.05f)
            {
                isDragging = true;
            }
        }
        if(isDragging)
        {
            onDragMove?.Invoke(mousePos, heldInteractable);
        }
    }

    public void SetHeldInteractable(BaseInteractable toHold)
    {
        heldInteractable = toHold;
        heldCursor.sharedMaterial = toHold.heldSpriteMaterial != null ? toHold.heldSpriteMaterial : defaultCursorMaterial;
        heldCursor.sprite = toHold.heldSprite != null ? toHold.heldSprite : missingCursor;
    }

    public void ClearHeldInteractable()
    {
        heldInteractable = null;
        heldCursor.sharedMaterial = defaultCursorMaterial;
        heldCursor.sprite = defaultCursor;
    }

    public void LateUpdate()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        heldCursor.transform.position = mousePos;
    }
}
