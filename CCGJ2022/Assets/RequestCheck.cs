using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestCheck : PotionBuilder
{
    public RequestScriptableObject request;
    [SerializeField]
    private RequestResponse response;

    [ContextMenu("Check Response")]
    public void CheckResponse() 
    {
        response = request.EvaluatePotion(this.currentPotion);
    }
}