using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemMovement))]
public class ItemMovementScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("type"));

        ItemMovement app = (ItemMovement)target;
        if (app.type == ItemMoveType.LeftRight || app.type == ItemMoveType.UpDown)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("maxDist"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("dir"));
        }
        EditorGUILayout.PropertyField(serializedObject.FindProperty("moveSpeed"));


        EditorGUILayout.PropertyField(serializedObject.FindProperty("isFlash"));
        if (app.isFlash)
        {
            if (app.isSameFlash)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("flashDelay"));
            }
            else
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("onFlashTime"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("offFlashTime"));
            }
            EditorGUILayout.PropertyField(serializedObject.FindProperty("isSameFlash"));
        }

        serializedObject.ApplyModifiedProperties();
    }
}