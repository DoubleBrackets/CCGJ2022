using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameplayDataAssets/Ingredient Asset", fileName = "New Ingredient Object")]
public class IngredientObject : PotionAttributeCollection
{
    public Sprite ingredientSprite;
    public string ingredientName;

    [TextArea]
    public string description;
    public override void UpdateAttribute(List<IngredientObject> ingredientList)
    {
        Debug.Log("No.");
    }
}
