using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item", menuName ="Scriptable/Item")]
public class ItemScriptables : ScriptableObject
{
    public string resourceName;
    public Sprite sprite;
    public GameObject model;
}
