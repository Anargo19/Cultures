using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Anargo
{
    public class BuidingManager : MonoBehaviour
    {
        [SerializeField] private bool isPlaced = false;
        [SerializeField] private BuildingScriptable building;
        private List<ItemScriptables> resourcesNeeded = new List<ItemScriptables>();
        
        private Material initial;
        private bool canPlace = false;
        GameManager manager = GameManager.instance;
        // Start is called before the first frame update
        void Start()
        {
            manager.leftClick.AddListener(Place);
            initial = GetComponent<MeshRenderer>().material;
            InitialPlacementCheck();
        }

        private void InitialPlacementCheck()
        {
            Mesh mesh = GetComponent<MeshFilter>().mesh;
            Material red = new Material(Shader.Find("Universal Render Pipeline/Lit"));

            float sphereRadius = Mathf.Max(mesh.bounds.size.x, mesh.bounds.size.z);
            int layerMask = 1 << 3;
            layerMask = ~layerMask;
            RaycastHit hit;
            if (Physics.SphereCast(transform.position, sphereRadius, Vector3.up, out hit, layerMask))
            {
                Debug.Log(hit.collider.name);
                red.color = Color.red;
                GetComponent<MeshRenderer>().material = red;
                canPlace = false;
                return;
            }

            red.color = Color.green;
            GetComponent<MeshRenderer>().material = red;
            canPlace = true;
        }

        void Place()
        {
            if (canPlace)
            {
                isPlaced = true;
                GetComponent<MeshRenderer>().material = initial;
                resourcesNeeded = building.resourcesNeeded.ToList();

            }
        }

        public ItemScriptables[] GetResourcesNeeded()
        {
            return resourcesNeeded.ToArray();
        }

        public void RemoveResource(ItemScriptables resource)
        {
            int index = resourcesNeeded.IndexOf(resource);
            resourcesNeeded.RemoveAt(index);
        }

        void CheckBuildingAdvancement()
        {
            float originalLength = building.resourcesNeeded.Length;
            float currentLength = resourcesNeeded.Count();
            float percentage = (originalLength - currentLength) / originalLength * 100;

            switch (percentage)
            {
                case <=0:
                    Debug.Log("Built");
                    break;
            }

        }

        // Update is called once per frame
        void Update()
        {
            if (!isPlaced)
            {
                FollowMouse();
            }
        }

        private void FollowMouse()
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
            RaycastHit hit;
            int layerMask = 1 << 3;
            if (Physics.Raycast(ray, out hit, 50, layerMask))
            {
                transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Terrain"))
                return;
            Material red = GetComponent<MeshRenderer>().material;
            red.color = Color.red;
            GetComponent<MeshRenderer>().material = red;
            canPlace = false;
        }

        private void OnTriggerExit(Collider other)
        {
            Material red = GetComponent<MeshRenderer>().material;
            red.color = Color.green;
            GetComponent<MeshRenderer>().material = red;
            canPlace = true;
        }
    }
}
