using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PotionAttributeLookup")]
public class PotionAttributeList : ScriptableObject
{
    [SerializeField]
    private PotionAttributeDictionary attributeData;


    public void OnValidate()
    {
        DisplayAttributes();
    }

    public void DisplayAttributes()
    {
        foreach(var attr in attributeData)
        {
            Debug.Log(attr);
        }
    }

    public void UpdateAttribute(List<IngredientObject> ingredientList)  
    {
        attributeData.Clear();
        foreach (var ingredient in ingredientList)
        {
            foreach (var attribute in ingredient.AttributeList.attributeData)
            {
                float value;
                if (attributeData.TryGetValue(attribute.Key, out value))
                {
                    value += attribute.Value;
                }
                else 
                {
                    attributeData.Add(attribute.Key, attribute.Value);
                }
            }
        }
    }
}

[System.Serializable]
public class PotionAttributeDictionary : SerializeableDictionary<PotionAttributeScriptableObject, float>
{ 
}