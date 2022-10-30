using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class GameManager : MonoBehaviour
{
    public InputActionAsset actions;
    public GameObject villagerActionPanel;
    public UnityEvent jobChanged = new UnityEvent();
    public GameObject selectedVillager;
    public static GameManager instance;
    public BuildingScriptable[] buildingList;
    public GameObject buildingManager;

    private void OnEnable()
    {
        
    }
    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LeftClick(CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            Debug.Log("Left clicked");
            Vector3 mousePos = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Resource")
                {
                    Debug.Log("Resource Clicked : " + hit.collider.GetComponentInParent<ResourceBehavior>().GetResourceScriptable().Name);
                }
                if (hit.collider.tag == "Storage")
                {
                    Debug.Log("Current Stocked : " + hit.collider.GetComponentInParent<FlagBehavior>().GetStorageAmount(hit.collider.transform));
                }
            }

        }



    }
    public void RightClick(CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            Debug.Log("Right clicked");
            Vector3 mousePos = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Villager")
                {
                    FollowScriptUI follow = villagerActionPanel.GetComponent<FollowScriptUI>();
                    follow.target = hit.collider.gameObject;
                    follow.isFollowing = true;
                    villagerActionPanel.SetActive(true);
                    selectedVillager = hit.collider.gameObject;
                }
                
            }

        }



    }

}
