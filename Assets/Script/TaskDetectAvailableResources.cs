using System.Collections.Generic;
using Anargo;
using UnityEngine;
using NodeCanvas.Framework;

public class TaskDetectAvailableResources : ActionTask
{

    public BBParameter<Vector3> pos;
    //public BBParameter<Transform> detectedPos;
    protected override void OnExecute()
    {
        Debug.Log(pos.value);
        HashSet<ItemScriptables> items = new HashSet<ItemScriptables>();
        RaycastHit[] hits = Physics.SphereCastAll(pos.value, 10, Vector3.forward);
        foreach (RaycastHit hit in hits)
        {
            Transform colliderTransform = hit.transform;
            if (colliderTransform == null) continue;
            
            if (colliderTransform.CompareTag("Item"))
            {
                ItemDeclaration itemDeclaration = colliderTransform.GetComponent<ItemDeclaration>();
                if (itemDeclaration == null) continue;
                if (itemDeclaration.item.type == ItemType.Resource)
                {
                    items.Add(itemDeclaration.item);
                }
            }
            
        }
        Debug.Log(items.Count);
        EndAction(true);
    }
}