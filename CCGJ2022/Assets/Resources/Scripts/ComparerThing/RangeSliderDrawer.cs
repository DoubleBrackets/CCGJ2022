using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

public class RangeSlider : PropertyAttribute
{
    public float minLim, maxLim;

    public RangeSlider(float minLim, float maxLim, bool roundToInt=false) 
    {
        this.minLim = minLim;
        this.maxLim = maxLim;
    }
}

[System.Serializable]
public struct RangeObject 
{
    public float min, max;
}

[CustomPropertyDrawer(typeof(RangeSlider))]
public class RangeSliderDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        int numberWidth = (int) position.width / 6;
        int sliderWidth = (int) position.width / 2;
        int padding = (int) position.width / 12;

        var sliderRect = new Rect(position.x + numberWidth + padding, position.y, sliderWidth, position.height);
        var minRect = new Rect(position.x, position.y, numberWidth, position.height);
        var maxRect = new Rect(position.x + numberWidth + sliderWidth + 2 * padding, position.y, numberWidth, position.height);
        
        RangeSlider range = attribute as RangeSlider;
        float a = property.FindPropertyRelative("min").floatValue;
        float b = property.FindPropertyRelative("max").floatValue;
        EditorGUI.MinMaxSlider(sliderRect, GUIContent.none, ref a, ref b, range.minLim, range.maxLim);
        property.FindPropertyRelative("min").floatValue = (int) a;
        property.FindPropertyRelative("max").floatValue = (int) b;
        
        EditorGUI.PropertyField(minRect, property.FindPropertyRelative("min"), GUIContent.none);
        EditorGUI.PropertyField(maxRect, property.FindPropertyRelative("max"), GUIContent.none);


        EditorGUI.EndProperty();
    }
}
