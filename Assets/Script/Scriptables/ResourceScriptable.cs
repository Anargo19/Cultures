using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Resource", menuName = "Scriptable/Resource")]
public class ResourceScriptable : ScriptableObject
{
    public string Name;
    public int amount;
    public GameObject baseModel;
    public GameObject middleModel;
    public GameObject endModel;
    public ItemScriptables itemDrop;
    public AudioClip[] sound;
}
