using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

//04.04.23

[CustomEditor(typeof(FZText))]

public class FZTextEditor : UnityEditor.UI.TextEditor
{
    public override void OnInspectorGUI()
    {
        FZText targetText = (FZText)target;
        targetText.timeInterval = EditorGUILayout.FloatField("Time Interval", targetText.timeInterval);
        targetText.textTranslationID = EditorGUILayout.TextField("Translation ID", targetText.textTranslationID);
        base.OnInspectorGUI();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(targetText);
            EditorSceneManager.MarkSceneDirty(targetText.gameObject.scene); 
        }
    }
}
