using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializeableDictionary<keytype ,value> : Dictionary<keytype, value>,ISerializationCallbackReceiver
{
    [System.Serializable]
    public struct DataPair
    {
        public keytype key;
        public value data;
    }

	[SerializeField]
	public List<DataPair> shownData = new List<DataPair>();

	void ISerializationCallbackReceiver.OnAfterDeserialize()
	{
        this.Clear();
        for(int i = 0;i < shownData.Count;i++)
        {
            if(shownData[i].key != null)
                this.Add(shownData[i].key, shownData[i].data);
        }
    }

	void ISerializationCallbackReceiver.OnBeforeSerialize()
	{
        for(int i = 0;i < shownData.Count;i++)
        {
            if(shownData[i].key != null)
            {
                shownData.RemoveAt(i);
                i--;
            }
        }
        foreach (var item in this)
        {
            shownData.Add(new DataPair { key = item.Key, data = item.Value });
        }
    }
}
