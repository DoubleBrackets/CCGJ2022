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
        attributeDict.Clear();
        foreach (var ingredient in ingredientList)
        {
            if (ingredient.attributeDict.totalAmount == 0) continue;
            foreach (var attribute in ingredient.attributeDict)
            {
                if (attributeDict.TryGetValue(attribute.Key, out float value))
                {
                    value += attribute.Value / ingredient.attributeDict.totalAmount / ingredientList.Count;
                }
                else 
                {
                    attributeDict.Add(attribute.Key, attribute.Value / ingredient.attributeDict.totalAmount / ingredientList.Count);
                }
            }
        }
    }
}