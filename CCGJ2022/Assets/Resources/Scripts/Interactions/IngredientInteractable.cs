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
    public override void OnInteractDownListener(Vector2 mousePos, BaseInteractable heldInteractable)
    {
        if (!IsInBounds(mousePos)) return;
        interactionContext.SetHeldInteractable(this);
    }

    public override void OnInteractUpListener(Vector2 mousePos, BaseInteractable heldInteractable)
    {
        //Do nothing
    }

    public override void OnInteractMouseMove(Vector2 mouesPos)
    {
        if (IsInBounds(mouesPos)) tooltipRenderer.ShowTooltip(sourceIngredient);
        else tooltipRenderer.HideTooltip(sourceIngredient);
    }

    public void OnValidate()
    {
        name = sourceIngredient.ingredientName;
        ingredientSpriteRen.sprite = sourceIngredient.ingredientSprite;
    }
}
