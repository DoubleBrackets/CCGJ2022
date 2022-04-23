using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializeableDictionary<key,value> : Dictionary<key, value>,ISerializationCallbackReceiver
{
    [System.Serializable]
    public struct DataPair
    {
        public key key;
        public value data;
    }

	[SerializeField]
	public List<DataPair> shownData = new List<DataPair>();

	void ISerializationCallbackReceiver.OnAfterDeserialize()
	{
        this.Clear();
        for(int i = 0;i < shownData.Count;i++)
        {
            if (shownData[i].key != null)
                this.Add(shownData[i].key, shownData[i].data);
        }
    }

	void ISerializationCallbackReceiver.OnBeforeSerialize()
	{
        shownData.Clear();
        foreach (var item in this)
        {
            shownData.Add(new DataPair { key = item.Key, data = item.Value });
        }
    }
}
