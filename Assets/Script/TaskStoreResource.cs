using UnityEngine;
using NodeCanvas.Framework;

public class TaskStoreResource : ActionTask
{

	public BBParameter<int> amount;
	public BBParameter<Transform> flag;
	protected override void OnExecute()
	{
		FlagBehavior flagBehavior = flag.value.GetComponent<FlagBehavior>();
		flagBehavior.ChangeAmount(amount.value);

		EndAction(true);
	}
}
