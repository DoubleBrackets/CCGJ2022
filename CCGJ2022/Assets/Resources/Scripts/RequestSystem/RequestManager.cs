using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestManager : MonoBehaviour
{
    public RequestScheduler requestScheduler;

    public GameObject initialRequestPrefab;
    public GameObject responsePrefab;


    public void CreateResponse(RequestScriptableObject request, RequestResponse response)
    {
        var envelope = Instantiate(responsePrefab);
        var letterInteractable = envelope.GetComponent<LetterInteractable>();
        letterInteractable.AssignRequest(this,request, response);
    }

    public void CreateRequest(RequestScriptableObject request)
    {
        var envelope = Instantiate(initialRequestPrefab);
        var letterInteractable = envelope.GetComponent<LetterInteractable>();
        letterInteractable.AssignRequest(this,request);
    }

    public void SubmitPotion(PotionObject potion,LetterInteractable letter,RequestScriptableObject request)
    {

    }
}
