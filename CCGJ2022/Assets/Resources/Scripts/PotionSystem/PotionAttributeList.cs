using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PotionAttributeLookup")]
public class PotionAttributeList : ScriptableObject
{
    [System.Serializable]
    struct DataPair {
        public PotionAttributeScriptableObject attribute;
        public float data;
    }
    [SerializeField]
    private List<DataPair> workingAttributes;

    public PotionAttributeList()
    {
        // attributeData = new Dictionary<PotionAttributeScriptableObject, float>();
        // foreach (var attribute in workingAttributes)
        // {
        //     attributeData.Add(attribute, 0);
        // }
    }



    public Dictionary<PotionAttributeScriptableObject, float> attributeData;

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
