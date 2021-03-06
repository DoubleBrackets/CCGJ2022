using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientInteractable : BaseInteractable
{
    public IngredientObject sourceIngredient;
    public SpriteRenderer ingredientSpriteRen;
    public TooltipRenderer tooltipRenderer;

    public void Awake()
    {
        heldSprite = sourceIngredient.ingredientSprite;
        ingredientSpriteRen.sprite = sourceIngredient.ingredientSprite;
    }
    public override void OnClickDownListener(Vector2 mousePos, BaseInteractable heldInteractable)
    {
        if (!IsInBounds(mousePos)) return;
        interactionContext.SetHeldInteractable(this);
        AudioManager.PlayOneShot("pop");
    }

    public override void OnMouseMoveListener(Vector2 mousePos, BaseInteractable heldInteractable)
    {
        if (IsInBounds(mousePos))
        {
            if(!tooltipRenderer.IsOpen)
            {
                AudioManager.PlayOneShot("chick");
                tooltipRenderer.ShowTooltip();
            }    
        }
        else
        {
            tooltipRenderer.HideTooltip();
        }
    }

    public void OnValidate()
    {
        name = sourceIngredient.ingredientName;
        ingredientSpriteRen.sprite = sourceIngredient.ingredientSprite;
    }
}
