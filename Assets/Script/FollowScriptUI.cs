using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScriptUI : MonoBehaviour
{
    public GameObject target;
    RectTransform transform;
    public bool isFollowing;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFollowing)
            transform.position = Camera.main.WorldToScreenPoint(target.transform.position);
    }
}
