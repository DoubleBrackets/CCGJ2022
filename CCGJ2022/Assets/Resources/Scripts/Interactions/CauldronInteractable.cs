using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronInteractable : BaseInteractable
{

    public override void OnInteractDownListener(Vector2 mousePos, BaseInteractable heldInteractable)
    {
        //Do nothing
    }

    public override void OnInteractUpListener(Vector2 mousePos, BaseInteractable heldInteractable)
    {
        if (!IsInBounds(mousePos)) return;
        if(heldInteractable.GetType() == typeof(IngredientInteractable))
        {
            print(((IngredientInteractable)heldInteractable).sourceIngredient.ingredientName);
        }
    }
}
