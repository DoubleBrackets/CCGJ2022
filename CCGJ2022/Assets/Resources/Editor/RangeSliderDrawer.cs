using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(RangeSlider))]
public class RangeSliderDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        //Min-Max Range slider
        RangeSlider range = attribute as RangeSlider;
        float a = property.FindPropertyRelative("min").floatValue;
        float b = property.FindPropertyRelative("max").floatValue;
        EditorGUI.LabelField(position, label.text);

        var sliderPos = new Rect(position.x + 145, position.y, position.width - 205, position.height);
        EditorGUI.MinMaxSlider(sliderPos, ref a, ref b, range.minLim, range.maxLim);
        if(range.roundToInt)
        {
            if (a != property.FindPropertyRelative("min").floatValue)
                a = (int)a;
            if (a != property.FindPropertyRelative("max").floatValue)
                b = (int)b;
        }
        // Draw label
        var minLabel = new Rect(position.x + 85, position.y, 45, position.height);
        var maxLabel = new Rect(position.width - 35, position.y, 45, position.height);
        a = EditorGUI.FloatField(minLabel, a);
        if (a > b)
            a = b;
        b = EditorGUI.FloatField(maxLabel, b);
        if (b < a)
            b = a;
        
        property.FindPropertyRelative("min").floatValue = a;
        property.FindPropertyRelative("max").floatValue = b;
        EditorGUI.EndProperty();
    }
}
