using NodeCanvas.BehaviourTrees;
using NodeCanvas.Framework;
using NodeCanvas.Tasks.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerJob : MonoBehaviour
{

    [SerializeField] Transform _flag;
    public Transform flag
    {
        get { return _flag; }
        set { }
    }
    [SerializeField] Transform pickupTransform;
    [SerializeField] Transform resource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FootR()
    {
        Debug.Log("Test");
        GetComponent<Animator>().SetBool("isCarrying", true);
        resource.gameObject.SetActive(true);
        Transform t = GetComponent<BehaviourTreeOwner>().graph.blackboard.GetVariable<Transform>("resourceDrop").value;
        if (t != null)
            Destroy(t.gameObject);
        
    }

    
}
