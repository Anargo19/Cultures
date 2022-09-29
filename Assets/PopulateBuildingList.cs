using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopulateBuildingList : MonoBehaviour
{
    [SerializeField] List<BuildingScriptable> buildings = new List<BuildingScriptable>();
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject resourceSpritePrefab;
    // Start is called before the first frame update
    void Start()
    {
        RectTransform _transform = GetComponent<RectTransform>();
        int i = 0;
        foreach (BuildingScriptable building in buildings)
        {
            GameObject _building = Instantiate(prefab, transform);
            Transform resourceList = _building.transform.GetChild(1);
            _building.GetComponentInChildren<TextMeshProUGUI>().text = building.name;

            foreach (ItemScriptables item in building.resourcesNeeded)
            {
                GameObject _item = Instantiate(resourceSpritePrefab, resourceList);
                _item.GetComponentInChildren<Image>().sprite = item.sprite;
            }
            /*
                if (i == buildings.Count - 1)
            {
                _transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _transform.sizeDelta.y + 45);
                continue;
            }

            _transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _transform.sizeDelta.y + 45);
            i++;*/
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
