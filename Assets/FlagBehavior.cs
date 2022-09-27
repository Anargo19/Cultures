using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagBehavior : MonoBehaviour
{
    [SerializeField] List<Transform> storagePlaces;
    [SerializeField] Transform currentStoragePlace;
    int _storageIndex = 0;
    [SerializeField] List<GameObject> resourcePrefabs = new List<GameObject>();
    [SerializeField] int _amount;
    // Start is called before the first frame update
    void Start()
    {
        _amount = 0;
        currentStoragePlace = storagePlaces[_storageIndex];

        if (currentStoragePlace.childCount > 0)
            Destroy(currentStoragePlace.GetChild(0).gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeAmount(int amount)
    {
        _amount += amount;
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
            currentStoragePlace = storagePlaces[_storageIndex];
        }

        
                        
    }
}
