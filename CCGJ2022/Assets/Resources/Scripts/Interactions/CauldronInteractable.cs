using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronInteractable : BaseInteractable
{
    public CouldronObject couldron;

    public PotionObject GetPotion()
    {
        return couldron.CurrentPotion;
    }
    public override void OnClickDownListener(Vector2 mousePos, BaseInteractable heldInteractable)
    {
        if (!IsInBounds(mousePos)) return;
        interactionContext.SetHeldInteractable(this);
    }

    public override void OnDragReleaseListener(Vector2 mousePos, BaseInteractable heldInteractable)
    {
        if (!IsInBounds(mousePos) || heldInteractable == null) return;
        if(heldInteractable.GetType() == typeof(IngredientInteractable))
        {
            couldron.AddIngredient(((IngredientInteractable)heldInteractable).sourceIngredient);
        }
        // TODO : else if (heldInteractable.GetType() == typeof(Bottle))
        {

        }
    }
}
 