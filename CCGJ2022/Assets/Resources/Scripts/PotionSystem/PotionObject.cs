using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionObject
{
    private PotionAttributeList attributeList;
    private List<IngredientObject> ingredientList;
    public PotionObject(PotionAttributeList sourceAttributes)
    {
        attributeList = ScriptableObject.Instantiate(sourceAttributes);
    }

    public void DisplayAttributes()
    {
        attributeList.DisplayAttributes();
    }

    public void AddIngredient(IngredientObject ingredient)
    {
        ingredientList.Add(ingredient);

        attributeList.UpdateAttribute(ingredientList);
    }
}
