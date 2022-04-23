using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializeablePotionAttributeDictionary : Dictionary<PotionAttributeScriptableObject, float>,ISerializationCallbackReceiver
{
    [SerializeField]
    public float totalAmount = 0;
    [System.Serializable]
    public struct DataPair
    {
        public PotionAttributeScriptableObject attribute;
        [Range(0,100)] public float amount;
    }

	[SerializeField]
	public List<DataPair> shownData = new List<DataPair>();

    private bool readyToSerialize = false;

	void ISerializationCallbackReceiver.OnAfterDeserialize()
	{
        var buffer = new Dictionary<PotionAttributeScriptableObject, float>();
        readyToSerialize = true;
        for(int i = 0;i < shownData.Count;i++)
        {
            if (shownData[i].attribute != null && !buffer.ContainsKey(shownData[i].attribute))
            {
                buffer.Add(shownData[i].attribute, shownData[i].amount);
            }
            else
            {
                readyToSerialize = false;
                return;
            }
        }
        this.Clear();
        totalAmount = 0;
        foreach (var pair in buffer)
        {
            Add(pair.Key,pair.Value);
            totalAmount += pair.Value;
        }
    }

	void ISerializationCallbackReceiver.OnBeforeSerialize()
	{
        if (!readyToSerialize)
            return;
        shownData.Clear();
        foreach (var item in this)
        {
            shownData.Add(new DataPair { attribute = item.Key, amount = item.Value });
        }
    }
}
