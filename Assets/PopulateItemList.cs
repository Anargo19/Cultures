using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopulateItemList : MonoBehaviour
{
    [SerializeField] List<ItemScriptables> items = new List<ItemScriptables>();
    [SerializeField] GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        RectTransform _transform = GetComponent<RectTransform>();
        int i = 0;
        foreach (ItemScriptables item in items)
        {
            GameObject _item = Instantiate(prefab, transform);
            _item.GetComponentInChildren<TextMeshProUGUI>().text = item.resourceName;
            if(i == items.Count - 1)
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
}
