using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestScheduler : MonoBehaviour
{
    public RequestManager requestManager;
    public OwlSystem owlSystem;

    [SerializeField] 
    public List<RequestScriptableObject> requestList;
    
    private int requestPointer;
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
        requestPointer = Random.Range(0, requestList.Count);
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
        currentRequests.Add(requestList[requestPointer]);
        owlSystem.QueueRequest(requestList[requestPointer]);
        requestPointer += Random.Range(1, 5);
        requestPointer %= requestList.Count;
    }

    public void RemoveRequest(RequestScriptableObject request)
    {
        currentRequests.Remove(request);
    }
}
