using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PotionAttributeLookup")]
public class PotionAttributeList : ScriptableObject
{  
    [SerializeField]
    public PotionAttributeDictionary workingAttributes;

    public void DisplayAttributes()
    {

    }

    public void OnValidate()
    {
        foreach(var val in workingAttributes)
        {
            Debug.Log(val.ToString());
        }
    }

}

[System.Serializable]
public class PotionAttributeDictionary : SerializeableDictionary<PotionAttributeScriptableObject, float>
{ }

