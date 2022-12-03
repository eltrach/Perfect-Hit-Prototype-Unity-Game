using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelGenerator))]
class LevelGeneratorEditor : Editor {

    public override void OnInspectorGUI() 
    {
        DrawDefaultInspector();

        LevelGenerator generator = (LevelGenerator)target;
        if(GUILayout.Button("Generate"))
        {
            generator.generateNewLevel();
        }
        if(GUILayout.Button("Clear"))
        {
            generator.ResetToDefault();
        }
    


    }
}