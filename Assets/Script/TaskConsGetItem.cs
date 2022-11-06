using System.Collections.Generic;
using Anargo;
using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

[Category("Anargo")]

public class TaskGetConsItem : ActionTask
{

	public BBParameter<ItemScriptables> resource;
	public BBParameter<Transform> building;
	protected override void OnExecute()
	{
		RaycastHit[] hits = Physics.SphereCastAll(building.value.position, 10, Vector3.forward);
		foreach (RaycastHit hit in hits)
		{
			Transform colliderTransform = hit.transform;
			if (!colliderTransform) continue;
            
			if (colliderTransform.CompareTag("Item"))
			{
				ItemDeclaration itemDeclaration = colliderTransform.GetComponent<ItemDeclaration>();
				if (!itemDeclaration) continue;
				if (!itemDeclaration.item) continue;
				if (itemDeclaration.item == resource.value)
				{
					resource.bb.SetVariableValue("resourcePos", colliderTransform);
					EndAction(true);
				}
			}
            
		}
		
		EndAction(false);
	}
}
