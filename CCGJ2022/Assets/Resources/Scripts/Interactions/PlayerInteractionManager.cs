using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class PlayerInteractionManager : MonoBehaviour
{
    public static PlayerInteractionManager instance;
    public Image heldCursor;
    public Image heldCursorAlternate;
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
    public Action<Vector2,BaseInteractable> onMouseMove;

    private BaseInteractable heldInteractable;
    private Vector2 startPos;
    private bool isDragging = false;
    private bool mouseDown = false;

    public void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        onMouseMove?.Invoke(mousePos, heldInteractable);
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
        heldCursor.material = toHold.heldSpriteMaterial != null ? toHold.heldSpriteMaterial : defaultCursorMaterial;
        heldCursor.sprite = toHold.heldSprite != null ? toHold.heldSprite : missingCursor;
    }

    public void SetCursorAlternate(Sprite sprite, Color color)
    {
        heldCursorAlternate.sprite = sprite;
        heldCursorAlternate.color = color;
        heldCursorAlternate.enabled = true;
    }

    public void ClearHeldInteractable()
    {
        heldInteractable = null;
        heldCursor.material = defaultCursorMaterial;
        heldCursor.sprite = defaultCursor;
        heldCursorAlternate.enabled = false;
    }

    public void LateUpdate()
    {
        Vector2 pos = Input.mousePosition;
        heldCursor.rectTransform.anchoredPosition = Input.mousePosition;
    }
}
