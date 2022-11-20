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
    [SerializeField] private JobScriptable job;
    public ResourceScriptable resourceScriptable
    {
        get { return _resourceScriptable; }
        set { }
    }
    [SerializeField] FlagBehavior _flag;
    public FlagBehavior flag
    {
        get { return _flag; }
        set { }
    }
    [SerializeField] Transform pickupTransform;
    [SerializeField] Transform resource;
    [SerializeField] Transform lumber;
    [SerializeField] int count = 0;
    [SerializeField] Transform tool;
    [SerializeField] Transform toolParent;

    [SerializeField] private AudioClip hammerSound;
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
    
    public float explosionRadius = 5.0f;

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    public void Pickup(string resourceName)
    {
        if (resourceName != "Lumber")
        {
            if (job.name == "Builder")
            {
                resource.gameObject.SetActive(true);
                Transform resourceObj = GetComponent<BehaviourTreeOwner>().graph.blackboard.GetVariable<Transform>("resourcePos").value;

                Instantiate(resourceObj, resource, false).localPosition = Vector3.zero;
                resource.gameObject.SetActive(true);
                if (resourceObj != null)
                    Destroy(resourceObj.gameObject);
                return;
            }
            
            
            GetComponent<Animator>().SetBool("isCarrying", true);
            if (resource.childCount > 0)
                Destroy(resource.GetChild(0).gameObject);
            Transform t = GetComponent<BehaviourTreeOwner>().graph.blackboard.GetVariable<Transform>("resourceDrop").value;

            Instantiate(t, resource, false).localPosition = Vector3.zero;
            resource.gameObject.SetActive(true);
            if (t != null)
                Destroy(t.gameObject);
            return;
        }
        lumber.gameObject.SetActive(true);
        Transform lumberObj = GetComponent<BehaviourTreeOwner>().graph.blackboard.GetVariable<Transform>("resourcePos").value;
        
        if (lumberObj != null)
            Destroy(lumberObj.gameObject);
    }

    
    public void PutDown(string type)
    {
        switch(type)
        {
            case "Building":
                lumber.gameObject.SetActive(false);
                break;
            default:
                if (job.name == "Builder")
                {
                    
                    resource.gameObject.SetActive(false);
                    break;
                }
                GetComponent<Animator>().SetBool("isCarrying", false);
                resource.gameObject.SetActive(false);
                flag.GetComponent<FlagBehavior>().ChangeAmount(1);
                break;
        }
        

    }

    public void StartStopTool()
    {
        tool.gameObject.SetActive(!tool.gameObject.activeSelf);
    }

    public void Strike(string type)
    {
        Debug.Log("Strike!");
        if (type == "Hammer")
        {
            AudioSource.PlayClipAtPoint(hammerSound, Camera.main.transform.position);
            return;
        }
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
        job = jobScriptable;
        BehaviourTreeOwner treeOwner = GetComponent<BehaviourTreeOwner>();
        treeOwner.SwitchBehaviour(jobScriptable.behaviourTree);
        tool.gameObject.SetActive(false);
        _resourceScriptable = jobScriptable.resourceNeeded;
        tool = toolParent.GetChild(jobScriptable.toolIndex);
        GetComponent<Animator>().Play("Idle");
        jobChanged.Invoke();
    }


}
