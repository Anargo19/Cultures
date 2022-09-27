using UnityEngine;
using NodeCanvas.Framework;

public class TaskDetectTag : ActionTask
{

	public BBParameter<Vector3> pos;
	public BBParameter<string> tag;
	public BBParameter<Transform> target;
	protected override void OnExecute()
	{
		RaycastHit[] hits = Physics.SphereCastAll(pos.value, 10, Vector3.forward);
		foreach (RaycastHit hit in hits)
		{
			Transform parent = hit.transform.parent;
			if (parent == null) continue;
			if (parent.gameObject == this.agent.gameObject) continue;
			if (parent.tag == tag.value)
			{
					Debug.Log(parent.position);
					target.bb.SetVariableValue("target", parent);
				
			}
		}
		Debug.Log(hits.Length);
		EndAction(true);
	}
}
