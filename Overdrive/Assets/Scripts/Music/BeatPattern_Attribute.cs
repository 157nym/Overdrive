using System;
using UnityEngine;
using System.Text;
using System.Text.RegularExpressions;

#if UNITY_EDITOR
using UnityEditor;
#endif


[AttributeUsage(AttributeTargets.Field)]
public class BeatPattern_Attribute : PropertyAttribute
{
    public readonly int PatternLength;
    public readonly int BeatInterval;

    public BeatPattern_Attribute(int PatternLength, int BeatInterval)
    {
        this.PatternLength = PatternLength;
        this.BeatInterval = BeatInterval;

    }
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(BeatPattern_Attribute))]
public class BeatPattern_Drawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType == SerializedPropertyType.String)
        {
            //setting the index number
            string number = Regex.Replace(label.text, @"\D", "");

            GUI.color = Color.green;
            Rect LabelRect = new Rect(position.x, position.y, 300, 20);
            GUI.Label(LabelRect, number);

            //setting the length of the string
            BeatPattern_Attribute bp = attribute as BeatPattern_Attribute;
            if(property.stringValue.Length != bp.PatternLength)
            {
                StringBuilder StartString = new StringBuilder();
                for(int i = 0; i < bp.PatternLength; i++)
                {
                    StartString.Append("0");
                }
                property.stringValue = StartString.ToString();
            }

            StringBuilder sb = new StringBuilder(property.stringValue);
            for(int i = 0; i < property.stringValue.Length; i++)
            {
                Rect buttonRect = new Rect(position.x + 21 + (20 * i), position.y, 19, 19);
                //colouring
                if(sb[i] == '1')
                {
                    GUI.color = Color.green;
                }
                else
                {
                    if(i % bp.BeatInterval == 0)
                    {
                        GUI.color = Color.red;
                    }
                    else
                    {
                        GUI.color = Color.black;
                    }
                }

                if (GUI.Button(buttonRect, GUIContent.none))
                {
                    if (sb[i] == '0')
                    {
                        sb[i] = '1';
                        property.stringValue = sb.ToString();
                    }
                    else
                    {
                        sb[i] = '0';
                        property.stringValue = sb.ToString();
                    }
                }
            }
        }
        else
        {
            GUI.color = Color.red;
            Rect LabelRect = new Rect(position.x, position.y, 300, 20);
            GUI.Label(LabelRect, "Beat Attribute only work with string");
        }

        GUI.color = Color.white;
    }

}
#endif