using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestManager : MonoBehaviour
{
    public RequestScheduler requestScheduler;

    public GameObject initialRequestPrefab;
    public GameObject responsePrefab;

    public Transform spawnZone;
    public float spawnRange;

    public void CreateResponse(RequestScriptableObject request, RequestResponse response)
    {
        var envelope = InstantiateInZone(responsePrefab);
        var letterInteractable = envelope.GetComponent<LetterInteractable>();
        letterInteractable.AssignRequest(this,request, response);
    }

    public void CreateRequest(RequestScriptableObject request)
    {
        var envelope = InstantiateInZone(initialRequestPrefab);
        var letterInteractable = envelope.GetComponent<LetterInteractable>();
        letterInteractable.AssignRequest(this,request);
    }

    private GameObject InstantiateInZone(GameObject toInstantiate)
    {
        var envelope = Instantiate(
            toInstantiate,
            (Vector2)spawnZone.transform.position + new Vector2(Random.Range(-spawnRange, spawnRange), Random.Range(-spawnRange, spawnRange)),
            Quaternion.Euler(0, 0, Random.Range(0, 360f)),
            spawnZone);
        return envelope;
    }

    public void SubmitPotion(PotionObject potion,LetterInteractable letter,RequestScriptableObject request)
    {
        RequestResponse response = request.EvaluatePotion(potion);
        CreateResponse(request, response);
        requestScheduler.RemoveRequest(request);
    }
}
