using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Anargo
{
    public class UiManager : MonoBehaviour
    {
        public static UiManager instance;
        private void Awake()
        {
            if (instance != null)
                Destroy(this);
            instance = this;
        }


        private GameManager _manager;
        public Camera follower;
        public GameObject villager;

        [Header("VillagerPanel")] 
        [SerializeField] private Transform _villagerPanel;
        [SerializeField] private TMP_InputField _villagerName;
        public TMP_InputField VillagerName => _villagerName;
        [SerializeField] private Image _villagerHealth;
        [SerializeField] private Image _villagerHunger;
        [SerializeField] private Image _villagerSleep;
        [SerializeField] private Image _villagerSocial;
        [SerializeField] private Image _villagerReligion;

        private VillagerStats _stats;

        public Transform VillagerPanel => _villagerPanel;


        [Header("BuildingPanel")]


        [SerializeField] private GameObject _buildingPanel;
        public GameObject BuildingPanel => _buildingPanel;
        [SerializeField] private RawImage _buildingFollow;
        public RawImage BuildingFollow => _buildingFollow;


        // Start is called before the first frame update
        void Start()
        {
            _manager = GameManager.instance;
            _manager.villagerSelectedEvent.AddListener(SetVillager);
        }

        // Update is called once per frame
        void Update()
        {
            if (_stats)
            {
                _villagerHealth.fillAmount = _stats.health/100;
                _villagerHunger.fillAmount = _stats.hunger/100;
                _villagerSocial.fillAmount = _stats.social/100;
            }
        }

        void SetVillager(VillagerStats stats)
        {
            _stats = stats;
            ShowVillagerPanel();
        }

        void ShowVillagerPanel()
        {
            
            _villagerPanel.gameObject.SetActive(true);
            _villagerName.text = _stats.name;
        }
    }
}
