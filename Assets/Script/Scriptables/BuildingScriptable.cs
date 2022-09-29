using NodeCanvas.BehaviourTrees;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Building", menuName = "Scriptable/Building")]
public class BuildingScriptable : ScriptableObject
{
    public string name;
    public Sprite sprite;
    public ItemScriptables[] resourcesNeeded;
}
