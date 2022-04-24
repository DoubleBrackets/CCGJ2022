
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestManager : MonoBehaviour
{
    public RequestScheduler requestScheduler;
    public OwlSystem owlSystem;

    public GameObject initialRequestPrefab;
    public GameObject responsePrefab;

    public Transform spawnZone;
    public float spawnRange;

    private List<LetterInteractable> letterInteractables = new List<LetterInteractable>();

    public void CreateResponse(RequestScriptableObject request, RequestResponse response)
    {
        var envelope = InstantiateInZone(responsePrefab);
        var letterInteractable = envelope.GetComponent<LetterInteractable>();
        letterInteractable.AssignRequest(this, request, response);
    }

    public void CreateRequest(RequestScriptableObject request)
    {
        var envelope = InstantiateInZone(initialRequestPrefab);
        var letterInteractable = envelope.GetComponent<LetterInteractable>();
        letterInteractable.AssignRequest(this, request);
        letterInteractables.Add(letterInteractable);
    }

    private GameObject InstantiateInZone(GameObject toInstantiate)
    {
        var envelope = Instantiate(
            toInstantiate,
            (Vector2)spawnZone.transform.position + new Vector2(Random.Range(-spawnRange, spawnRange), Random.Range(-spawnRange, spawnRange)),
            Quaternion.Euler(0, 0, Random.Range(-75f, 75f)),
            spawnZone);
        return envelope;
    }

    public void CollectFilledRequests()
    {
        for (int i = 0; i < letterInteractables.Count; i++)
        {
            if (letterInteractables[i].HeldResponse != null)
            {
                SubmitPotion(letterInteractables[i].HeldResponse, letterInteractables[i], letterInteractables[i].AttachedRequest);
                Destroy(letterInteractables[i].gameObject);
                letterInteractables.RemoveAt(i);
                i--;
            }
        }
    }

    public void SubmitPotion(RequestResponse response,LetterInteractable letter, RequestScriptableObject request)
    {
        requestScheduler.RemoveRequest(request);
        owlSystem.QueueResponse(request,response);
    }
}
