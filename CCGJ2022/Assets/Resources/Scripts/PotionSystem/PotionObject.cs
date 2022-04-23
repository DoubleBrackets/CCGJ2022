using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionObject
{
    private PotionAttributeList attributeList;
    public PotionObject(PotionAttributeList sourceAttributes)
    {
        attributeList = ScriptableObject.Instantiate(sourceAttributes);
    }

    public void DisplayAttributes()
    {
        attributeList.DisplayAttributes();
    }
}
