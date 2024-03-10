using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

//07.04.23

[CustomEditor(typeof(FZText))]

public class FZTextEditor : UnityEditor.UI.TextEditor
{
    SerializedProperty translation;

    protected override void OnEnable()
    {
        base.OnEnable();
        translation = serializedObject.FindProperty("translations");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        FZText targetText = (FZText)target;
        targetText.timeInterval = EditorGUILayout.FloatField("Time Interval", targetText.timeInterval);
        EditorGUILayout.PropertyField(translation);


        AppearanceControlsGUI();
        RaycastControlsGUI();
        MaskableControlsGUI();
        serializedObject.ApplyModifiedProperties();

        base.OnInspectorGUI();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(targetText);
            EditorSceneManager.MarkSceneDirty(targetText.gameObject.scene);
        }
    }
}
