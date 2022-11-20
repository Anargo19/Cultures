using UnityEngine;
using NodeCanvas.Framework;

public class TaskStoreResource : ActionTask
{

	public BBParameter<int> amount;
	public BBParameter<FlagBehavior> flag;
	protected override void OnExecute()
	{
		//flag.value.GetStorageAmount();

		EndAction(true);
	}
}
