using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBuilder : MonoBehaviour
{
    public PotionAttributeList sourceAttributeList;
    private PotionObject currentPotion;
    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            currentPotion = new PotionObject(sourceAttributeList);
        }
    }

}
