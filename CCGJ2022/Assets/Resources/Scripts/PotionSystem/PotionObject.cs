using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionObject
{
    private PotionAttributeCollection attributeCollection;

    public PotionAttributeCollection AttributeCollection
    {
        get => attributeCollection;
    }

    private List<IngredientObject> ingredientList = new List<IngredientObject>();
    public PotionObject(PotionAttributeCollection sourceAttributes)
    {
        attributeCollection = ScriptableObject.Instantiate(sourceAttributes);
    }

    public void DisplayAttributes()
    {
        attributeCollection.DisplayAttributes();
    }

    public void AddIngredient(IngredientObject ingredient)
    {
        ingredientList.Add(ingredient);

        attributeCollection.UpdateAttribute(ingredientList);
    }

    public void ResetPotion()
    {
        ingredientList.Clear();
        attributeCollection.UpdateAttribute(ingredientList);
    }
}
