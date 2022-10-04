using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopulateJobList : MonoBehaviour
{
    [SerializeField] List<JobScriptable> jobs = new List<JobScriptable>();
    [SerializeField] GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        RectTransform _transform = GetComponent<RectTransform>();
        int i = 0;
        foreach (JobScriptable job in jobs)
        {
            GameObject _job = Instantiate(prefab, transform);
            _job.GetComponentInChildren<TextMeshProUGUI>().text = job.name;
            if(i == jobs.Count - 1)
            {
                _transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _transform.sizeDelta.y + 38);
                continue;
            }

            _transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _transform.sizeDelta.y + 39);
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public JobScriptable GetJob(int index)
    {
        return jobs[index];
    }
}
