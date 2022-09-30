using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagBehavior : MonoBehaviour
{
    [SerializeField] Dictionary<Transform, int> storagePlaces = new Dictionary<Transform, int>();
    [SerializeField] GameObject villager;
    ResourceScriptable resource;
    [SerializeField] Transform currentStoragePlace;
    int _storageIndex = 0;
    [SerializeField] GameObject[] resourcePrefabs;
    [SerializeField] int _amount;
    // Start is called before the first frame update
    void Start()
    {
        resource = villager.GetComponent<VillagerJob>().resourceScriptable;
        resourcePrefabs = resource.storageModels;
        foreach(Transform t in transform)
        {
            if(t.tag == "Storage")
                storagePlaces.Add(t, 0);

        }
        _amount = 0;
        currentStoragePlace = transform.GetChild(0);

        if (currentStoragePlace.childCount > 0)
            Destroy(currentStoragePlace.GetChild(0).gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeAmount(int amount)
    {
        storagePlaces[currentStoragePlace] += amount;
        _amount = storagePlaces[currentStoragePlace];
        if (currentStoragePlace.childCount > 0)
            Destroy(currentStoragePlace.GetChild(0).gameObject);
        if (_amount == 0)
            return;
        Debug.Log(_amount);
        Instantiate(resourcePrefabs[_amount - 1], currentStoragePlace);
        if(_amount == 5)
        {
            _storageIndex++;
            _amount = 0;
            foreach(KeyValuePair<Transform, int> keyValuePair in storagePlaces)
            {
                if(keyValuePair.Value < 5)
                    currentStoragePlace = keyValuePair.Key;
            }
        }

        
                        
    }

    public int GetStorageAmount(Transform storage)
    {
        return storagePlaces[storage];
    }
}
