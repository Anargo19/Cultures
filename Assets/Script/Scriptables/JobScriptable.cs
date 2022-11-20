using NodeCanvas.BehaviourTrees;
using System.Collections;
using System.Collections.Generic;
using Anargo;
using Sirenix.OdinInspector;
using UnityEngine;


public enum JobType
{
    Extractor,
    CreationJob,
    Civilian
}

[CreateAssetMenu(fileName = "Job", menuName = "Scriptable/Job")]
public class JobScriptable : SerializedScriptableObject
{
    public string name;
    public BehaviourTree behaviourTree;
    public JobType jobType;

    [Header("Extractor")]
    [HideIf("@jobType != JobType.Extractor")]
    public ResourceScriptable resourceNeeded;
    [HideIf("@jobType != JobType.Extractor")]
    public int toolIndex;


    [HideIf("@jobType != JobType.CreationJob")]
    public Dictionary<RecipeScriptable, int> recipes = new Dictionary<RecipeScriptable, int>();
}
