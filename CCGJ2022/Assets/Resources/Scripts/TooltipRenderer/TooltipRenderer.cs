using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipRenderer : MonoBehaviour
{

    public void ShowTooltip(IngredientObject ingredient) 
    {
        gameObject.SetActive(true);
    }

    public void HideTooltip(IngredientObject ingredient) 
    {
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
