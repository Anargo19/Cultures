using NodeCanvas.BehaviourTrees;
using NodeCanvas.Framework;
using NodeCanvas.Tasks.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerJob : MonoBehaviour
{
    [SerializeField] ResourceScriptable _resourceScriptable; 
    public ResourceScriptable resourceScriptable
    {
        get { return _resourceScriptable; }
        set { }
    }
    [SerializeField] Transform _flag;
    public Transform flag
    {
        get { return _flag; }
        set { }
    }
    [SerializeField] Transform pickupTransform;
    [SerializeField] Transform resource;
    int count = 0;
    [SerializeField] Transform pickaxe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pickup()
    {
        GetComponent<Animator>().SetBool("isCarrying", true);
        if (resource.childCount > 0)
            Destroy(resource.GetChild(0).gameObject);
        Transform t = GetComponent<BehaviourTreeOwner>().graph.blackboard.GetVariable<Transform>("resourceDrop").value;

        Instantiate(t, resource, false).localPosition = Vector3.zero;
        resource.gameObject.SetActive(true);
        if (t != null)
            Destroy(t.gameObject);

    }
    public void PutDown()
    {
        GetComponent<Animator>().SetBool("isCarrying", false);
        resource.gameObject.SetActive(false);
        flag.GetComponent<FlagBehavior>().ChangeAmount(1);

    }

    public void StartStopTool()
    {
        pickaxe.gameObject.SetActive(!pickaxe.gameObject.activeSelf);
    }

    public void Strike()
    {
        count++;
        AudioSource.PlayClipAtPoint(resourceScriptable.sound[Random.Range(0, resourceScriptable.sound.Length - 1)], Camera.main.transform.position);
        if (count < 3)
        {
            return;
        }
        Transform t = GetComponent<BehaviourTreeOwner>().graph.blackboard.GetVariable<Transform>("resource").value.GetComponent<ResourceBehavior>().RemoveResource();
        GetComponent<BehaviourTreeOwner>().graph.blackboard.SetVariableValue("resourceDrop", t);
        count = 0;

    }

    public void SetJob(Object @object)
    {

    }


}
