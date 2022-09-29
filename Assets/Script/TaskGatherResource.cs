using UnityEngine;
using NodeCanvas.Framework;

public class TaskGatherResource : ActionTask
{

	ResourceScriptable resourceScriptable;
	public BBParameter<Transform> resource;
	protected override void OnExecute()
	{
		Debug.Log(resource);
		ResourceBehavior behavior = resource.value.GetComponent<ResourceBehavior>();
		resourceScriptable = behavior.GetResourceScriptable();
		resource.bb.SetVariableValue("resourceDrop", behavior.RemoveResource());

		EndAction(true);
	}
}
