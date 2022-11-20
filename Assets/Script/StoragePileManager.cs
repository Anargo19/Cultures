using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anargo
{
    public class StoragePileManager : MonoBehaviour
    {
        private ItemScriptables _item;
        private int _amount = 0;

        public ItemScriptables Item => _item;
        public int Amount => _amount;

        public void ChangeAmount(int amount)
        {
            if(_amount<=0)
                return;
            _amount += amount;
            if(_amount<=0)
                Destroy(gameObject);
        }

        public void SetItem(ItemScriptables item)
        {
            _item = item;
        }
    }
}
