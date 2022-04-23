using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Comparer Object", fileName = "New Comparer Object")]
public class Comparer : ScriptableObject
{
    [SerializeField]
    public Vector2 field;

    [RangeSlider(-10,10)]
    public Vector2 test;


    void OnValidate() {
        Debug.Log(test);
    }
}
