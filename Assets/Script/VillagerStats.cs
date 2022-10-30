using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerStats : MonoBehaviour
{
    [SerializeField]
    private float _health;
    [SerializeField]
    private float _maxhealth;
    [SerializeField]
    private float _hunger;
    [SerializeField]
    private float _maxhunger;
    [SerializeField]
    private float _social;
    [SerializeField]
    private float _maxsocial;

    public float health
    {
        get { return _health; }
        set { }
    }

    public float hunger
    {
        get { return _hunger; }
        set { }
    }
    public float social
    {
        get { return _social; }
        set { }
    }


    // Start is called before the first frame update
    void Start()
    {
        _hunger = _maxhunger;
        _health = _maxhealth;
        _social = _maxsocial;
        StartCoroutine(HungerDecay());
        StartCoroutine(SocialDecay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator HungerDecay()
    {
        while (true)
        {
            _hunger -= 3;
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator SocialDecay()
    {
        while (true)
        {
            _social -= 3;
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void ChangeHealthAmount(int amount)
    {
        _health += amount;
    }
    public void ChangeHungerAmount(int amount)
    {
        _hunger += amount;
    }
    public void ChangeSocialAmount(int amount)
    {
        _social += amount;
    }
}
