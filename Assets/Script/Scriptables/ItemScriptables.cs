using System.Collections;
using System.Collections.Generic;
using Anargo;
using UnityEngine;

public enum ItemType
{
    Generic,
    Weapon,
    Armor,
    Resource
}


[CreateAssetMenu(fileName = "Item", menuName = "Scriptable/Item")]
public class ItemScriptables : ScriptableObject
{
    public string resourceName;
    public Sprite sprite;
    public GameObject model;
    public ItemType type;
}
