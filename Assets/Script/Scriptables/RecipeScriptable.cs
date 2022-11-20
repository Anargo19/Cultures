using NodeCanvas.BehaviourTrees;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Anargo
{
    [CreateAssetMenu(fileName = "Recipe", menuName = "Scriptable/Recipe")]
    public class RecipeScriptable : SerializedScriptableObject
    {
        
        public Dictionary<ItemScriptables, int> InResources = new Dictionary<ItemScriptables, int>();
        public Dictionary<ItemScriptables, int> OutResources = new Dictionary<ItemScriptables, int>();
    }
}