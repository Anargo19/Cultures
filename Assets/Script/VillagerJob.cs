using NodeCanvas.BehaviourTrees;
using NodeCanvas.Framework;
using NodeCanvas.Tasks.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VillagerJob : MonoBehaviour
{
    public UnityEvent jobChanged = new UnityEvent();
    GameManager manager;
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
    [SerializeField] Transform tool;
    [SerializeField] Transform toolParent;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
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
        tool.gameObject.SetActive(!tool.gameObject.activeSelf);
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

    public void SetJob(JobScriptable jobScriptable)
    {
        Debug.Log(jobScriptable.name);
        BehaviourTreeOwner treeOwner = GetComponent<BehaviourTreeOwner>();
        treeOwner.SwitchBehaviour(jobScriptable.behaviourTree);
        tool.gameObject.SetActive(false);
        _resourceScriptable = jobScriptable.resourceNeeded;
        tool = toolParent.GetChild(jobScriptable.toolIndex);
        jobChanged.Invoke();
    }


}
