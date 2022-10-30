using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Anargo
{
    public class BuidingManager : MonoBehaviour
    {
        [SerializeField] private bool isPlaced = false;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (!isPlaced)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                transform.position = new Vector3(pos.x, transform.position.y, pos.z);
            }
        }
    }
}
