#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ResourceBehavior))]
public class ResourceBehaviorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ResourceBehavior behavior = (ResourceBehavior)target;

        if (GUILayout.Button("Test"))
            behavior.RemoveResource();

    }
}
#endif