using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;

[CreateAssetMenu(fileName = "New Request Asset",menuName = "GameplayDataAssets/Request Asset")]
public class RequestScriptableObject : ScriptableObject
{
    public TextAsset requestText;
    [TextArea]
    public List<string> texts;

    public void OnValidate()
    {
        AssetDatabase.Refresh();
        texts = new List<string>(requestText.ToString().Split(new string[] { "#"}, System.StringSplitOptions.RemoveEmptyEntries));
        texts = texts.Select(x => x.TrimStart(new char[] { '\r', '\n' })).ToList();
    }

    public string GetInitialRequestText()
    {
        return texts.Count > 0 ? texts[0] : string.Empty;
    }

    public string GetResponseText(int index)
    {
        return texts.Count > index ? texts[index] : string.Empty;
    }
}

[System.Serializable]
public class RequestResponse
{
    public TextAsset responseText;


}
