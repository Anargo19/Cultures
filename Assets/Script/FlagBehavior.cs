using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagBehavior : MonoBehaviour
{
    [SerializeField] VillagerJob _villager;
    [SerializeField] Transform currentStoragePlace;
    int _storageIndex = 0;
    [SerializeField] BoxCollider _resourcePrefab;
    [SerializeField] int _amount;
    [SerializeField] int _maxAmount = 5;
    // Start is called before the first frame update
    void Start()
    {
        _villager.jobChanged.AddListener(ChangeResource);
        if (!currentStoragePlace)
        {
            Vector3 pos = SpawnObject();
            currentStoragePlace = Instantiate(_resourcePrefab.transform, pos, Quaternion.identity);
            _amount = 0;
            _villager.ChangeStockPile.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeAmount(int amount)
    {
        
        bool setActive = amount > 0;
        if (setActive && _amount == _maxAmount)
        {
            Vector3 pos = SpawnObject();
            currentStoragePlace = Instantiate(_resourcePrefab.transform, pos, Quaternion.identity);
            _amount = 0;
            _villager.ChangeStockPile.Invoke();
        }
        Debug.Log(currentStoragePlace.transform);
        Debug.Log(currentStoragePlace.transform.GetChild(_amount));
        currentStoragePlace.transform.GetChild(_amount).gameObject.SetActive(setActive);
        _amount += amount;
        

    }

    public int GetStorageAmount(Transform storage)
    {
        return _amount;
    }
    public Transform GetStockPile()
    {
        return currentStoragePlace;
    }

    void ChangeResource()
    {
    }
    
    private Vector3 SpawnObject()
    {
        float radius = Mathf.Max(_resourcePrefab.size.x, _resourcePrefab.size.z) / 2;
        bool isFree = false;
        Vector3 pos = Vector3.zero;
        while (!isFree)
        {
            pos = new Vector3(transform.position.x + Random.Range(-3, 3), 0, transform.position.z + Random.Range(-3, 3));
            Debug.Log(pos);
            int layerMask = 1 << 3; 
            layerMask = ~layerMask;

            Collider[] hitColliders = Physics.OverlapSphere(pos, radius, layerMask);
            if (hitColliders.Length > 0)
            {
                isFree = false;

            }
            else
                isFree = true;

            if (Vector3.Distance(transform.position, pos) < 0.5f)
                isFree = false;
        }
        return pos;
    }
}
