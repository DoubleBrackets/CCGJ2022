using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;

[CreateAssetMenu(fileName = "New Request Asset",menuName = "GameplayDataAssets/Request Asset")]
public class RequestScriptableObject : ScriptableObject
{
    public TextAsset requestText;
    [SerializeField]public string initialRequestText;
    [SerializeField] public List<RequestResponse> responses;

    public void OnValidate()
    {
#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
        var texts = new List<string>(requestText.ToString().Split(new string[] { "#"}, System.StringSplitOptions.RemoveEmptyEntries));
        texts = texts.Select(x => x.TrimStart(new char[] { '\r', '\n' })).ToList();

        initialRequestText = texts.Count > 0 ? texts[0] : string.Empty;
        for (int i = 0;i < responses.Count;i++)
        {
            responses[i].responseText = i + 1 < texts.Count ? texts[i + 1] : string.Empty;
        }
    }

    private RequestResponse defaultResponse = new RequestResponse();
    public RequestResponse EvaluatePotion(PotionObject potion) 
    {
        foreach (var response in responses) 
        {
            if (response.responseRequirements.Compare(potion.AttributeCollection))
                return response;
        }
        return defaultResponse;
    }
}

[System.Serializable]
public class RequestResponse
{
    [HideInInspector]public string dontask = "";
    [TextArea]public string responseText;
    public Comparer responseRequirements;
}
