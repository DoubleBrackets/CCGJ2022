using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;

[CreateAssetMenu(fileName = "New Request Asset",menuName = "Request Asset")]
public class RequestScriptableObject : ScriptableObject
{
    public TextAsset requestText;

    public string GetRequestText()
    {
        return requestText.text;
    }

    
}

[System.Serializable]
public class RequestResponse
{
    public TextAsset responseText;


}
