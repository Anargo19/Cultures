using UnityEngine;
using NodeCanvas.Framework;

public class TaskDetectCollision : ActionTask
{

	public BBParameter<Vector3> pos;
	public BBParameter<ResourceScriptable> resource;
	public BBParameter<Transform> resourcePos;
	protected override void OnExecute()
	{
		RaycastHit[] hits = Physics.SphereCastAll(pos.value, 10, Vector3.forward);
		foreach (RaycastHit hit in hits)
		{
			//Transform parent = hit.transform.parent;
			Transform resourceTransform = hit.transform;
			//if (parent == null) continue;
			if (resourceTransform.GetComponent<ResourceBehavior>() != null)
			{
				Debug.Log($"Collider name {resource.name}, if is resource, is type : {resourceTransform.GetComponent<ResourceBehavior>().GetResourceScriptable()}");
				if (resourceTransform.tag == "Resource" && resourceTransform.GetComponent<ResourceBehavior>().GetResourceScriptable() == resource.value)
				{
					Debug.Log(resourceTransform.position);
					resourcePos.bb.SetVariableValue("resource", hit.transform);
				}
			}
		}
		EndAction(true);
	}
}
