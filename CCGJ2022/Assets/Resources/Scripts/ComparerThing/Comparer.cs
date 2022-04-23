using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameplayDataAssets/Comparer Asset", fileName = "New Comparer Object")]
public class Comparer : ScriptableObject
{
    [SerializeField]
    public Vector2 field;

    [RangeSlider(0,100)]
    public Vector2 test;


    void OnValidate() {
        Debug.Log(test);
    }
}
