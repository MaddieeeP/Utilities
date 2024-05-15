using UnityEngine;
using UnityEditor;

public class ArrayElementTitleAttribute : PropertyAttribute
{
    private string _varname;

    public string varname { get { return _varname; } }

    public ArrayElementTitleAttribute(string variableName)
    {
        _varname = variableName;
    }
}

[CustomPropertyDrawer(typeof(ArrayElementTitleAttribute))]
public class ArrayElementTitleDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty titleNameProperty = property.serializedObject.FindProperty(property.propertyPath + "." + ((ArrayElementTitleAttribute)attribute).varname);
        
        string title = label.text;
        switch (titleNameProperty.propertyType)
        {
            case SerializedPropertyType.Integer:
                title = titleNameProperty.intValue.ToString();
                break;
            case SerializedPropertyType.Float:
                title = titleNameProperty.floatValue.ToString();
                break;
            case SerializedPropertyType.String:
                title = titleNameProperty.stringValue;
                break;
            case SerializedPropertyType.Enum:
                title = titleNameProperty.enumNames[titleNameProperty.enumValueIndex];
                break;
            default:
                break;
        }

        EditorGUI.PropertyField(position, property, new GUIContent(title, label.tooltip), true);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }
}