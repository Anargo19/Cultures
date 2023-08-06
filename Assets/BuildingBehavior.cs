using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anargo
{
    public class BuildingBehavior : MonoBehaviour, IStorage, IDamageable, IInteractable
    {
        private int _health;
        public void Dies()
        {
            throw new System.NotImplementedException();
        }

        public int GetAmount(ItemScriptables item)
        {
            throw new System.NotImplementedException();
        }

        public int GetStorage()
        {
            throw new System.NotImplementedException();
        }

        public void Heal(int amount)
        {
            throw new System.NotImplementedException();
        }

        public void Interact()
        {
            Debug.Log($"Interacted with building named {gameObject.name}");
            UiManager.instance.BuildingPanel.SetActive(true);
            UiManager.instance.follower.transform.LookAt(transform);
        }

        public void RemoveItem(ItemScriptables item)
        {
            throw new System.NotImplementedException();
        }

        public void Store(ItemScriptables item)
        {
            throw new System.NotImplementedException();
        }

        public void TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
