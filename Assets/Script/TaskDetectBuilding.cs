using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

[Category("Anargo")]
public class TaskDetectBuilding : ActionTask
{

    public BBParameter<Vector3> pos;
    public BBParameter<string> tag;
    public BBParameter<Transform> detectedPos;
    protected override void OnExecute()
    {
        RaycastHit[] hits = Physics.SphereCastAll(pos.value, 30, Vector3.forward);
        foreach (RaycastHit hit in hits)
        {
                if (hit.transform.CompareTag(tag.value))
                {
                    Debug.Log(hit.transform.position);
                    detectedPos.bb.SetVariableValue("Building", hit.transform);
                }
            
        }
        Debug.Log(hits.Length);
        EndAction(true);
    }
}