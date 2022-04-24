using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipRenderer : MonoBehaviour
{
    public bool renderUp;
    private IngredientObject ingredient;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
