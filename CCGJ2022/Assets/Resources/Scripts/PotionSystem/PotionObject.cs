using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionObject
{
    private PotionAttributeCollection attributeList;
    private List<IngredientObject> ingredientList;
    public PotionObject(PotionAttributeCollection sourceAttributes)
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
