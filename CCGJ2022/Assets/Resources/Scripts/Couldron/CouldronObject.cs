using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouldronObject : MonoBehaviour
{
    public SpriteRenderer potionContents;
    public ParticleSystem potionSteam;
    public ParticleSystem potionBurst;
    public float colorLerpTime;
    private float colorLerpTimer;
    private PotionObject currentPotion;

    private Color targetColor;

    public Color TargetColor => targetColor;

    private Color prevColor;
    public int maxIngredients;

    public PotionObject CurrentPotion 
    {
        get => currentPotion;
    }

    public StatsBarMenu statsBar;
    // Start is called before the first frame update
    void Start()
    {
        currentPotion = new PotionObject(ScriptableObject.CreateInstance<PotionAttributeCollection>(), maxIngredients);
        statsBar.Display(currentPotion.AttributeCollection);
        colorLerpTimer = colorLerpTime;
        potionSteam.SetStartColor(Color.Lerp(Color.white,potionContents.color,0.5f));
        targetColor = potionContents.color;
    }


    public void AddIngredient(IngredientObject ingredient) 
    {
        currentPotion.AddIngredient(ingredient);
        statsBar.Display(currentPotion.AttributeCollection);
        //Color change
        prevColor = potionContents.color;
        float a = potionContents.color.a;
        Color c = currentPotion.AttributeCollection.CalculateAverageColor();
        c.a = a;
        targetColor = c;
        colorLerpTimer = 0f;
        potionBurst.SetStartColor(ingredient.CalculateAverageColor());
        potionBurst.Play();
    }
    // Update is called once per frame


    private void Update()
    {
        if(colorLerpTimer < colorLerpTime)
        {
            colorLerpTimer += Time.deltaTime;
            potionContents.color = Color.Lerp(prevColor, targetColor, Mathf.Min(1f, colorLerpTimer / colorLerpTime));
            potionSteam.SetStartColor(Color.Lerp(Color.white, potionContents.color, 0.5f));            
        }
    }
}
