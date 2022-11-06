using System.Collections.Generic;
using Anargo;
using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

[Category("Anargo")]
public class TaskGetConstructionResource : ActionTask
{

	public BBParameter<Transform> building;
	public BBParameter<List<ItemScriptables>> availables;
	protected override void OnExecute()
	{
		ItemScriptables[] resources = building.value.GetComponent<BuildingManager>().GetResourcesNeeded();
		foreach (ItemScriptables item in resources)
		{
			if (!availables.value.Contains(item))
				continue;
			building.bb.SetVariableValue("resource", item);
			EndAction(true);
		}
		
		EndAction(false);
	}
}
