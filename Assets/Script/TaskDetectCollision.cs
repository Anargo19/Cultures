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
			Transform parent = hit.transform.parent;
			if (parent == null) continue;
			if (parent.GetComponent<ResourceBehavior>() != null)
			{
				Debug.Log($"Collider name {parent.name}, if is resource, is type : {parent.GetComponent<ResourceBehavior>().GetResourceScriptable()}");
				if (parent.tag == "Resource" && parent.GetComponent<ResourceBehavior>().GetResourceScriptable() == resource.value)
				{
					Debug.Log(parent.position);
					resourcePos.bb.SetVariableValue("resource", parent);
				}
			}
		}
		Debug.Log(hits.Length);
		EndAction(true);
	}
}
