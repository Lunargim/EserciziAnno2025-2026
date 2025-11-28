using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Item))]
public class ItemCustomEditor : Editor
{
    override public void OnInspectorGUI()
    {
        var item = target as Item;  
        var name = serializedObject.FindProperty(nameof(Item.name));
        EditorGUILayout.PropertyField(name);
        
        SerializedProperty spriteProperty + serializedObject.FindProperty((nameof(Item.icon)));
    }
    
    
}
