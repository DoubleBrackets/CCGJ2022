using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct RangeObject 
{
    public float min, max;

    public bool check(float val) 
    {
        return min <= val && val <= max;
    }
}

[CreateAssetMenu(menuName = "Comparer Object", fileName = "New Comparer Object")]
public class Comparer : ScriptableObject
{
    [System.Serializable]
    public struct Requirement 
    {
        public PotionAttributeScriptableObject attribute;

        [RangeSlider(0,100)]
        public RangeObject value;
    }
    [SerializeField]
    List<Requirement> requirementList = new List<Requirement>();


    public bool Compare(PotionAttributeCollection attributes) 
    {
        foreach (Requirement requirement in requirementList) 
        {
            float value = 0;
            if (attributes.AttributeDict.ContainsKey(requirement.attribute)) 
                value = attributes.AttributeDict[requirement.attribute];
            if (!requirement.value.check(value)) 
                return false;
        }
        return true;
    }
}