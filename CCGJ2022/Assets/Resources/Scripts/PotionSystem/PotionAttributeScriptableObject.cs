using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Potion Attribute",fileName = "New Potion Attribute")]
public class PotionAttributeScriptableObject : ScriptableObject
{
    public Sprite attributeSprite;
    private string attributeName;
    public string displayName;

        [TextArea]
        public string description;

    public void OnValidate()
    {
        attributeName = this.name;
        //Debug.Log(attributeName);
    }

    public override string ToString()
    { 
        return attributeName;
    }
}
 