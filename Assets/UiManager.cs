using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anargo
{
    public class UiManager : MonoBehaviour
    {
        public Camera follower;
        public GameObject villager;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 lookAt = new Vector3(villager.transform.position.x, villager.transform.position.y + 0.5f,
                villager.transform.position.z);
            follower.transform.LookAt(lookAt);
        }
    }
}
