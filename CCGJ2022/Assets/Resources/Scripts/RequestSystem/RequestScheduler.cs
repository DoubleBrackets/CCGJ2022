using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestScheduler : MonoBehaviour
{
    public RequestManager requestManager;
    public OwlSystem owlSystem;

    [SerializeField] 
    public List<RequestScriptableObject> requestList;
    
    private Queue<RequestScriptableObject> requestsToGiveToPlayerBeforeTheGameEnds = new Queue<RequestScriptableObject>();
    [SerializeField]
    private float requestTime = 25f;
    [SerializeField]
    private float requestDeviation = 0.2f;
    [SerializeField]
    private int maxRequests = 3;
    [SerializeField]
    private float nextRequest = -1;
    [SerializeField]
    public List<RequestScriptableObject> currentRequests;

    // Start is called before the first frame update
    void Start()
    {
       foreach (var request in requestList) 
       {
           requestsToGiveToPlayerBeforeTheGameEnds.Enqueue(request);
       }
    }

    // Update is called once per frame
    void Update()
    {
        if ((maxRequests - currentRequests.Count) > 0) 
        {
            if (nextRequest > 0 && nextRequest < Time.time) 
            {
                GenerateRequest();
                nextRequest = -1;
            }
            else 
            {
                if (nextRequest < 0  || nextRequest > Time.time + requestTime * 1 / (maxRequests - currentRequests.Count) + requestDeviation * requestTime)
                {
                    nextRequest = Time.time + requestTime * 1 / (maxRequests - currentRequests.Count) + requestDeviation * Random.Range(-requestTime, requestTime);
                }
            }
        }
    }

    public void GenerateRequest() {
        if (requestsToGiveToPlayerBeforeTheGameEnds.Count == 0) return;
        var nextRequestToGiveToPlayer = requestsToGiveToPlayerBeforeTheGameEnds.Dequeue();
        currentRequests.Add(nextRequestToGiveToPlayer);
        owlSystem.QueueRequest(nextRequestToGiveToPlayer);

    }

    public void RemoveRequest(RequestScriptableObject request, RequestResponse response)
    {
        if (response.responseRequirements.tryAgain) {
            requestsToGiveToPlayerBeforeTheGameEnds.Enqueue(request);
        }
        currentRequests.Remove(request);
    }

    public bool RequestsFinished()
    {
        return (currentRequests.Count == 0 && requestsToGiveToPlayerBeforeTheGameEnds.Count == 0);
    }
}
