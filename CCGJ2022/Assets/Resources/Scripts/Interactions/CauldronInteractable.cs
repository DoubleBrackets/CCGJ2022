using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronInteractable : BaseInteractable
{
    public CouldronObject couldron;
    public Sprite potionLiquidSprite;

    public PotionObject GetPotion()
    {
        return couldron.CurrentPotion;
    }
    public override void OnClickDownListener(Vector2 mousePos, BaseInteractable heldInteractable)
    {
        if (!IsInBounds(mousePos)) return;
        interactionContext.SetHeldInteractable(this);
    }

    public override void OnDragBeginListener(Vector2 mousePos, BaseInteractable heldInteractable)
    {
        if (heldInteractable != this) return;
        interactionContext.SetCursorAlternate(potionLiquidSprite, couldron.TargetColor);
        AudioManager.PlayOneShot("bottlefill");
    }

    public override void OnDragReleaseListener(Vector2 mousePos, BaseInteractable heldInteractable)
    {
        if (!IsInBounds(mousePos) || heldInteractable == null) return;
        if(heldInteractable.GetType() == typeof(IngredientInteractable))
        {
            couldron.AddIngredient(((IngredientInteractable)heldInteractable).sourceIngredient);
            AudioManager.PlayOneShot("swish2");
        }
        // TODO : else if (heldInteractable.GetType() == typeof(Bottle))
        {

        }
    }
}
 