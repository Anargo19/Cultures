using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Resource", menuName = "Scriptable/Resource")]
public class ResourceScriptable : ItemScriptables
{
    public int amount;
    public GameObject middleModel;
    public GameObject endModel;
    public ItemScriptables itemDrop;
    public AudioClip[] sound;
    public GameObject[] storageModels;
}
