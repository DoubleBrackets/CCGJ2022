using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionObject
{
    private PotionAttributeCollection attributeCollection;
    private int maxIngredients;

    public PotionAttributeCollection AttributeCollection
    {
        get => attributeCollection;
    }

    private Queue<IngredientObject> ingredientList = new Queue<IngredientObject>();
    public PotionObject(PotionAttributeCollection sourceAttributes, int maxIngredients=10)
    {
        this.maxIngredients = maxIngredients;
        attributeCollection = ScriptableObject.Instantiate(sourceAttributes);
    }

    public void DisplayAttributes()
    {
        attributeCollection.DisplayAttributes();
    }

    public void AddIngredient(IngredientObject ingredient)
    {
        ingredientList.Enqueue(ingredient);
        while (ingredientList.Count > maxIngredients) ingredientList.Dequeue();

        attributeCollection.UpdateAttribute(new List<IngredientObject>(ingredientList));
    }

    public void ResetPotion()
    {
        ingredientList.Clear();
        attributeCollection.UpdateAttribute(new List<IngredientObject>(ingredientList));
    }
}
