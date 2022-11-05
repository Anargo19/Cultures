using UnityEngine;
using NodeCanvas.Framework;

public class TaskDetectBuilding : ActionTask
{

    public BBParameter<Vector3> pos;
    public BBParameter<string> tag;
    public BBParameter<Transform> detectedPos;
    protected override void OnExecute()
    {
        RaycastHit[] hits = Physics.SphereCastAll(pos.value, 10, Vector3.forward);
        foreach (RaycastHit hit in hits)
        {
                if (hit.transform.CompareTag(tag.value))
                {
                    Debug.Log(hit.transform.position);
                    detectedPos.bb.SetVariableValue("resource", hit.transform);
                }
            
        }
        Debug.Log(hits.Length);
        EndAction(true);
    }
}