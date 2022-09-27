using UnityEngine;
using NodeCanvas.Framework;

public class TaskGatherResource : ActionTask
{

	ResourceScriptable resourceScriptable;
	public BBParameter<Transform> resource;
	protected override void OnExecute()
	{
		ResourceBehavior behavior = resource.value.GetComponent<ResourceBehavior>();
		resourceScriptable = behavior.GetResourceScriptable();
		behavior.RemoveResource();

		EndAction(true);
	}
}
