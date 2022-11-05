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
        HashSet<ItemScriptables> items = new HashSet<ItemScriptables>();
        RaycastHit[] hits = Physics.SphereCastAll(pos.value, 10, Vector3.forward);
        foreach (RaycastHit hit in hits)
        {
            Transform parent = hit.transform.parent;
            if (parent == null) continue;
            
            if (parent.CompareTag("Item"))
            {
                ItemDeclaration itemDeclaration = parent.GetComponent<ItemDeclaration>();
                if (itemDeclaration == null) continue;
                if (itemDeclaration.item.type == ItemType.Resource)
                {
                    items.Add(itemDeclaration.item);
                }
            }
            
        }
        Debug.Log(hits.Length);
        EndAction(true);
    }
}