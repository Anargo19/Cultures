using NodeCanvas.BehaviourTrees;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Anargo
{
    [CreateAssetMenu(fileName = "Building", menuName = "Scriptable/Building")]
    public class BuildingScriptable : ScriptableObject
    {
        
        public string name;
        [PreviewField(150, ObjectFieldAlignment.Center)]
        public Sprite sprite;
        [TableList]
        public ItemScriptables[] resourcesNeeded;
        [PreviewField]
        public GameObject[] constructionStages;

        public JobScriptable[] workerType;
    }
}

