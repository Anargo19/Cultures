using System.Collections;
using System.Collections.Generic;
using Anargo;
using UnityEngine;

public class PlayUiSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(Object sound)
    {
        if (sound.GetType() != typeof(AudioClip))
            return;
        AudioClip clip = (AudioClip)sound;
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }

    public void SetJob()
    {
        GameManager manager = GameManager.instance;
        manager.selectedVillager.GetComponent<VillagerJob>().SetJob(transform.parent.GetComponent<PopulateJobList>().GetJob(transform.GetSiblingIndex()));
        
    }

    public void PlaceBuilding()
    {
        GameManager manager = GameManager.instance;
        BuildingScriptable building =  manager.buildingList[transform.GetSiblingIndex()];

        Instantiate(building.constructionStages[0]);
        transform.parent.parent.parent.parent.gameObject.SetActive(false);

    }

}
