using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PotionAttributeCollection")]
public class PotionAttributeCollection : ScriptableObject
{
    [SerializeField]
    private SerializeablePotionAttributeDictionary attributeDict;

    public SerializeablePotionAttributeDictionary AttributeDict
    {
        get => attributeDict;
    }


    public void OnValidate()
    {
        DisplayAttributes();
    }

    public void DisplayAttributes()
    {
        foreach (var attr in attributeDict)
        {
            Debug.Log(attr);
        }
    }

    public virtual void UpdateAttribute(List<IngredientObject> ingredientList)  
    {
        attributeDict.totalAmount = 0;
        attributeDict.Clear();
        foreach (var ingredient in ingredientList)
        {
            if (ingredient.attributeDict.totalAmount == 0) continue;
            foreach (var attribute in ingredient.attributeDict)
            {   
                float normalizedIngredientAttributeAmount = attribute.Value / ingredient.attributeDict.totalAmount / ingredientList.Count * 100;
                if (attributeDict.ContainsKey(attribute.Key))
                {
                    attributeDict[attribute.Key] += normalizedIngredientAttributeAmount;
                }
                else 
                {
                    attributeDict.Add(attribute.Key, normalizedIngredientAttributeAmount);
                }
                attributeDict.totalAmount += normalizedIngredientAttributeAmount;
            }
        }
    }
}