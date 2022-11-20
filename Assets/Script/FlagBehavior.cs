using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagBehavior : MonoBehaviour
{
    [SerializeField] VillagerJob villager;
    [SerializeField] Transform currentStoragePlace;
    int _storageIndex = 0;
    [SerializeField] GameObject[] resourcePrefabs;
    [SerializeField] int _amount;
    // Start is called before the first frame update
    void Start()
    {
        villager.jobChanged.AddListener(ChangeResource);
        if (!currentStoragePlace)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeAmount(int amount)
    {

        
                        
    }

    public int GetStorageAmount(Transform storage)
    {
        return 0;
    }

    void ChangeResource()
    {
    }
}
