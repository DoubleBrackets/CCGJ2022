using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientInteractable : BaseInteractable
{
    public IngredientObject sourceIngredient;
    public SpriteRenderer ingredientSpriteRen;

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

    public void OnValidate()
    {
        ingredientSpriteRen.sprite = sourceIngredient.ingredientSprite;
    }
}
