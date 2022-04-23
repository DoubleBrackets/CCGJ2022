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

    private bool readyToSerialize = false;

	void ISerializationCallbackReceiver.OnAfterDeserialize()
	{
        var buffer = new Dictionary<keytype, value>();
        readyToSerialize = true;
        for(int i = 0;i < shownData.Count;i++)
        {
            if (shownData[i].key != null && !buffer.ContainsKey(shownData[i].key))
            {
                buffer.Add(shownData[i].key, shownData[i].data);
            }
            else
            {
                readyToSerialize = false;
                return;
            }
        }
        this.Clear();
        foreach (var pair in buffer)
            Add(pair.Key,pair.Value);
    }

	void ISerializationCallbackReceiver.OnBeforeSerialize()
	{
        if (!readyToSerialize)
            return;
        shownData.Clear();
        foreach (var item in this)
        {
            shownData.Add(new DataPair { key = item.Key, data = item.Value });
        }
    }
}
