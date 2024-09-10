using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(JSONFileManager))]
public class JsonManagerEditor : Editor
{
    JSONFileManager Target;
    private void OnEnable()
    {
        Target = (JSONFileManager)target;
        Debug.Log("je suis appeller");
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (Application.isPlaying) 
        { 
            if (Target.wordRequestResult == null)
            {
                // EditorGUILayout.LabelField("aucun mot n'a ete choisi");
                EditorGUILayout.HelpBox("aucun mot n'a ete choisi", MessageType.Warning );
            }
            else
            {
                EditorGUILayout.LabelField($"Mot choisi: {Target.wordRequestResult.motChoisi}");
            }
        }
        if (GUILayout.Button("Testing"))
        {
            Debug.Log("jai été clicker");
        }
    }
}
