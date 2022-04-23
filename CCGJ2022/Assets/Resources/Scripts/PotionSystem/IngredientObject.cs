using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientObject
{
    private PotionAttributeList attributeList;

    public PotionAttributeList AttributeList
    {
        get => attributeList;
    }
    public IngredientObject(PotionAttributeList sourceAttributes)
    {
        attributeList = ScriptableObject.Instantiate(sourceAttributes);
    }
    
    public void DisplayAttributes()
    {
        attributeList.DisplayAttributes();
    }
}
