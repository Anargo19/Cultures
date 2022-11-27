using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anargo
{
    
    [Serializable]
    public class WorkerEmplacement
    {
        public WorkerEmplacement(JobScriptable _job, VillagerJob _villager)
        {
            job = _job;
            villager = _villager;
        }
        public JobScriptable job;
        public VillagerJob villager;
    }
    
    public class BuildingWorkManager : MonoBehaviour
    {
        public List<WorkerEmplacement> workers = new List<WorkerEmplacement>();
        public BuildingScriptable building;

        // Start is called before the first frame update
        void Start()
        {
            if (workers.Count == 0)
            {
                foreach (JobScriptable job in building.workerType)
                {
                    workers.Add(new WorkerEmplacement(job, null));
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
