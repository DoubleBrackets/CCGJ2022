using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipRenderer : MonoBehaviour
{
    public bool renderUp;

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
        if (renderUp) gameObject.transform.position += new Vector3(0,40,0);
        else gameObject.transform.position += new Vector3(0,-40,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
