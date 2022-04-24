using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TooltipRenderer : MonoBehaviour
{
    public bool renderUp;
    private IngredientObject ingredient;
    public GameObject slider;
    private List<GameObject> sliders = new List<GameObject>();

    public void ShowTooltip() 
    {
        gameObject.SetActive(true);
    }

    public void HideTooltip() 
    {
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        ingredient = gameObject.GetComponentInParent<IngredientInteractable>().sourceIngredient;
        if (renderUp) gameObject.transform.position += new Vector3(0,4,0);
        else gameObject.transform.position += new Vector3(0,-4,0);
        gameObject.GetComponentInChildren<TMPro.TextMeshPro>().text = ingredient.ingredientName;

        foreach (var attribute in ingredient.AttributeDict) 
        {
            sliders.Add(GameObject.Instantiate(slider, gameObject.transform));
            sliders.Last().transform.position += sliders.Count * new Vector3(0, -1, 0);
            sliders.Last().GetComponentInChildren<TMPro.TextMeshPro>().text = attribute.Key.displayName;
            var sprite = sliders.Last().GetComponentInChildren<SpriteRenderer>();
            var scale = sprite.transform.localScale;
            var pos = sprite.transform.position;
            pos.x -= (100 - attribute.Value) / 40;
            scale.x = attribute.Value / 20 + 0.2f;
            sprite.transform.localScale = scale;
            sprite.transform.position = pos;
            sprite.color = attribute.Key.attributeColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
