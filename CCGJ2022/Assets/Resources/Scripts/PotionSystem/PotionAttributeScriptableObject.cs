using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Potion Attribute",fileName = "New Potion Attribute")]
public class PotionAttributeScriptableObject : ScriptableObject
{
    public Sprite attributeSprite;
    public string attributeName;

    public override string ToString()
    {
        return attributeName;
    }
}
