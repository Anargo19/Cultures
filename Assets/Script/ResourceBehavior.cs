using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBehavior : MonoBehaviour
{
    [SerializeField] ResourceScriptable resource;
    int _amount;
    Vector3 _position;

    // Start is called before the first frame update
    void Start()
    {
        GameObject newResource = Instantiate(resource.baseModel, transform);

        _amount = resource.amount;
        _position = transform.position;


    }

    // Update is called once per frame
    void Update()
    {

    }

    public ResourceScriptable GetResourceScriptable()
    {
        return resource;
    }

    public void RemoveResource()
    {
        _amount--;

        float percentage = (float)(resource.amount + (_amount - resource.amount)) / (float)resource.amount * 100;
        Debug.Log(percentage);

        switch (percentage)
        {
            case > 75:
                Destroy(transform.GetChild(0).gameObject);
                Instantiate(resource.baseModel, transform);
                break;
            case < 75 and > 30:
                Destroy(transform.GetChild(0).gameObject);
                Instantiate(resource.middleModel, transform);
                break;
            case <= 35 and > 0:
                Destroy(transform.GetChild(0).gameObject);
                Instantiate(resource.endModel, transform);
                break;
            case <= 0:
                Destroy(gameObject);
                break;
        }
        Vector3 pos = Vector3.zero;
        pos = SpawnDrop();
        _position = pos;

        GameObject item = Instantiate(resource.itemDrop.model);
        item.transform.position = pos;
        AudioSource.PlayClipAtPoint(resource.sound[Random.Range(0, resource.sound.Length - 1)], Camera.main.transform.position);
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(_position, 0.5f);
    }

    private Vector3 SpawnDrop()
    {

        bool isFree = false;
        RaycastHit hit2;
        Vector3 pos = Vector3.zero;
        while (!isFree)
        {
            pos = new Vector3(transform.position.x + Random.Range(-3, 3), 0, transform.position.z + Random.Range(-3, 3));
            Debug.Log(isFree);
            Collider[] hitColliders = Physics.OverlapSphere(pos, 0.5f);
            if (hitColliders.Length > 0)
            {
                isFree = false;

            }
            else
                isFree = true;

            if (Vector3.Distance(transform.position, pos) < 1)
                isFree = false;
        }
        return pos;
    }
}