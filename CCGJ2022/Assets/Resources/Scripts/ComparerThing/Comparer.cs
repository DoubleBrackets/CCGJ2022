using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "GameplayDataAssets/Comparer Asset", fileName = "New Comparer Object")]
[System.Serializable]
public class Comparer 
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

public class RangeSlider : PropertyAttribute
{
    public float minLim, maxLim;
    public bool roundToInt;

    public RangeSlider(float minLim, float maxLim, bool roundToInt = true)
    {
        this.minLim = minLim;
        this.maxLim = maxLim;
        this.roundToInt = roundToInt;
    }
}

[System.Serializable]
public struct RangeObject
{
    public float min, max;

    public bool check(float val)
    {
        return min <= val && val <= max;
    }
}
