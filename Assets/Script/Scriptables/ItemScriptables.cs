using System.Collections;
using System.Collections.Generic;
using Anargo;
using Sirenix.OdinInspector;
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
    [TextArea]
    public string resourceName;
    [PreviewField(ObjectFieldAlignment.Center)]
    public Sprite sprite;
    [PreviewField(ObjectFieldAlignment.Center)]
    public GameObject model;
    public ItemType type;
}
