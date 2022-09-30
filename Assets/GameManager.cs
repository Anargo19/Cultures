using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class GameManager : MonoBehaviour
{
    public InputActionAsset actions;

    private void OnEnable()
    {
        
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

}
