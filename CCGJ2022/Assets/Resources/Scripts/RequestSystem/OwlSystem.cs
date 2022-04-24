using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlSystem : MonoBehaviour
{
    public float cycleTime;
    public float travelTime;
    public float waitTime;
    public float preDelay;
    public Vector2 pos1;
    public Vector2 pos2;

    public GameObject owlSprite;

    public RequestScheduler scheduler;
    public RequestManager manager;

    [SerializeField]
    private List<RequestScriptableObject> requestsToDeliver = new List<RequestScriptableObject>();
    [SerializeField]
    private List<(RequestScriptableObject,RequestResponse)> responsesToDeliver = new List<(RequestScriptableObject, RequestResponse)> ();

    public bool IsOwlSystemEmpty()
    {
        return requestsToDeliver.Count == 0 && responsesToDeliver.Count == 0;
    }

    private void Start()
    {
        StartCoroutine(Cycle());
    }

    private IEnumerator Cycle()
    {
        yield return new WaitForSeconds(preDelay);
        while(true)
        {
            float timer = 0f;
            while(timer <= travelTime)
            {
                timer += Time.deltaTime;
                owlSprite.transform.position = Vector3.Lerp(pos1, pos2, Mathf.Min(1,timer / travelTime));
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForSeconds(waitTime - 0.2f);
            AudioManager.PlayOneShot("paperdrop");
            yield return new WaitForSeconds(0.2f);
            //Collect
            Deliver();

            timer = 0f;
            while (timer <= travelTime)
            {
                timer += Time.deltaTime;
                owlSprite.transform.position = Vector3.Lerp(pos1, pos2, Mathf.Min(1,1 - timer / travelTime));
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForSeconds(cycleTime);
        }
    }

    public void QueueRequest(RequestScriptableObject request)
    {
        requestsToDeliver.Add(request);
    }

    public void QueueResponse(RequestScriptableObject request, RequestResponse response)
    {
        responsesToDeliver.Add((request, response));
    }

    public void DeliverAllRequests()
    {
        foreach(var request in requestsToDeliver)
        {
            manager.CreateRequest(request);
        }
        requestsToDeliver.Clear();
    }

    public void DeliverAllResponses()
    {
        foreach(var response in responsesToDeliver)
        {
            manager.CreateResponse(response.Item1, response.Item2);
        }
        responsesToDeliver.Clear();
    }

    public void Deliver()
    {
        DeliverAllRequests();
        DeliverAllResponses();
        manager.CollectFilledRequests();
    }
}
