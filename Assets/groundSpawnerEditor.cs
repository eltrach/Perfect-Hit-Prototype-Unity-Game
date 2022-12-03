using UnityEngine;
using UnityEditor;

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
        }
    }
}