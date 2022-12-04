using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;

[CustomEditor(typeof(groundSpawner))]
class groundSpawnerEditor : Editor {
    public override void OnInspectorGUI() 
    {
        DrawDefaultInspector();

        groundSpawner spawner = (groundSpawner)target;
        if(GUILayout.Button("Generate"))
        {
            spawner.spawn();
        }
        if(GUILayout.Button("Clear"))
        {
            spawner.ResetToDefault();
            ClearLogConsole();
        }
        if(GUILayout.Button("Save as a Prefab"))
        {
            spawner.SaveGeneratedLevelAsPrefab();
        }
        
    }
    public static void ClearLogConsole() 
    {
        var assembly = Assembly.GetAssembly(typeof(SceneView));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
}