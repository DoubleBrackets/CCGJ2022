using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBuilder : MonoBehaviour
{
    public IngredientObject dummyIngredientObject;
    [SerializeField]
    public SerializeablePotionAttributeDictionary readAttribute;
    protected PotionObject currentPotion;


    private void Awake()
    {
        currentPotion = new PotionObject(ScriptableObject.CreateInstance<PotionAttributeCollection>());
    }

    private void Update()
    {
        readAttribute = currentPotion.AttributeCollection.AttributeDict;
    }

    [ContextMenu("Reset Potion")]
    public void ResetPotion()
    {
        currentPotion.ResetPotion();
    }

    [ContextMenu("Add dummy ingredient")]
    public void AddDummyIngredient()
    {
        currentPotion.AddIngredient(dummyIngredientObject);
    }

}
