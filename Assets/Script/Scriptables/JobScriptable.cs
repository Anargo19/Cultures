using NodeCanvas.BehaviourTrees;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Job", menuName = "Scriptable/Job")]
public class JobScriptable : ScriptableObject
{
    public string name;
    public BehaviourTree behaviourTree;
    public ResourceScriptable resourceNeeded;
}
