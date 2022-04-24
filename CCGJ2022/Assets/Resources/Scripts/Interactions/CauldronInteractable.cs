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
    public override void OnInteractDownListener(Vector2 mousePos, BaseInteractable heldInteractable)
    {
        if (!IsInBounds(mousePos)) return;
        interactionContext.SetHeldInteractable(this);
    }

    public override void OnInteractUpListener(Vector2 mousePos, BaseInteractable heldInteractable)
    {
        if (!IsInBounds(mousePos)) return;
        if(heldInteractable.GetType() == typeof(IngredientInteractable))
        {
            couldron.AddIngredient(((IngredientInteractable)heldInteractable).sourceIngredient);
        }
        // TODO : else if (heldInteractable.GetType() == typeof(Bottle))
        {

        }
    }
}
 