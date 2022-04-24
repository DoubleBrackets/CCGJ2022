using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouldronObject : MonoBehaviour
{
    private PotionObject currentPotion;
    public PotionObject CurrentPotion 
    {
        get => currentPotion;
    }

    public StatsBarMenu statsBar;
    // Start is called before the first frame update
    void Start()
    {
        currentPotion = new PotionObject(ScriptableObject.CreateInstance<PotionAttributeCollection>());
        statsBar.Display(currentPotion.AttributeCollection);
    }


    public void AddIngredient(IngredientObject ingredient) 
    {
        currentPotion.AddIngredient(ingredient);
        statsBar.Display(currentPotion.AttributeCollection);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
