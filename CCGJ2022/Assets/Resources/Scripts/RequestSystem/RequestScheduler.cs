using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestScheduler : MonoBehaviour
{
    public RequestManager requestManager;

    [SerializeField] 
    public List<RequestScriptableObject> requestList;
    
    private int requestPointer;
    private float requestTime = 20f;
    private float requestDeviation = 0.25f;
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
        requestManager.CreateRequest(requestList[requestPointer]);
        requestPointer += Random.Range(1, 5);
        requestPointer %= requestList.Count;
    }

    public void RemoveRequest(RequestScriptableObject request)
    {
        currentRequests.Remove(request);
    }
}
