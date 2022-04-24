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
    }


    public Action<Vector2,BaseInteractable> onInteractDown;
    public Action<Vector2,BaseInteractable> onInteractUp;
    public Action<Vector2> onMouseMove;

    private BaseInteractable heldInteractable;

    public void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        onMouseMove?.Invoke(mousePos);
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
                heldCursor.sharedMaterial = defaultCursorMaterial;
            }
        }
    }

    public void SetHeldInteractable(BaseInteractable toHold)
    {
        heldInteractable = toHold;
        heldCursor.sharedMaterial = toHold.heldSpriteMaterial != null ? toHold.heldSpriteMaterial : defaultCursorMaterial;
        heldCursor.sprite = toHold.heldSprite != null ? toHold.heldSprite : missingCursor;
    }

    public void LateUpdate()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        heldCursor.transform.position = mousePos;
    }
}
