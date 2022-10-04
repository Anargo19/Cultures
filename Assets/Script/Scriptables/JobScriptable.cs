using NodeCanvas.BehaviourTrees;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum JobType
{
    Extractor,
    CreationJob,
    Civilian
}

[CreateAssetMenu(fileName = "Job", menuName = "Scriptable/Job")]
public class JobScriptable : ScriptableObject
{
    public string name;
    public BehaviourTree behaviourTree;
    public JobType jobType;

    [Header("Extractor")]
    public ResourceScriptable resourceNeeded;
    public int toolIndex;
}
