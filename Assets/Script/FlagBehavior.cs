using Anargo;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlagBehavior : MonoBehaviour, IStorage
{
    [SerializeField] VillagerJob _villager;
    ResourceScriptable _resource;
    public Transform currentStoragePlace;
    //int _storageIndex = 0;
    [SerializeField] BoxCollider _resourcePrefab;
    [SerializeField] int _amount;
    // Start is called before the first frame update
    void Start()
    {
        _villager.jobChanged.AddListener(ChangeResource);
        
    }


    void ChangeResource()
    {
        if (_resource == _villager.resourceScriptable)
            return;
        _resource= _villager.resourceScriptable;
        currentStoragePlace = Instantiate(_resourcePrefab, transform).transform;
        currentStoragePlace.position = transform.position;
        _villager.ChangeStockPile.Invoke();
            
    }
    
   


    public void RemoveItem(ItemScriptables item)
    {
        if(_amount <= 0) return;

        if (item != _resource) return;

        _amount--;
        if (_amount > 5) return;
        currentStoragePlace.GetChild(_amount - 1).gameObject.SetActive(true);
    }


    public int GetAmount(ItemScriptables item)
    {
        if (item != _resource) return 0;

        return _amount;
    }


    public void Store(ItemScriptables item)
    {

        if (item != _resource) return;

        _amount++;

        if (_amount > 5) return;
        currentStoragePlace.GetChild(_amount-1).gameObject.SetActive(true);

    }

    public int GetStorage()
    {
        return _amount;
    }
}
