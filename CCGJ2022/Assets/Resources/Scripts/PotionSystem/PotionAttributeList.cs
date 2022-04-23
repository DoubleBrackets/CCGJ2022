using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PotionAttributeLookup")]
public class PotionAttributeList : ScriptableObject
{

    public PotionAttributeList()
    {
        attributeData = new Dictionary<PotionAttributeScriptableObject, float>();
        foreach (var attribute in workingAttributes)
        {
            attributeData.Add(attribute, 0);
        }
    }

    [SerializeField]
    private List<PotionAttributeScriptableObject> workingAttributes;


    public Dictionary<PotionAttributeScriptableObject, float> attributeData;

    public void DisplayAttributes()
    {
        foreach(var attr in attributeData)
        {
            
        }
    }
}
