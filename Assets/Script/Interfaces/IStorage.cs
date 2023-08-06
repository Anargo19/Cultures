using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anargo
{
    public interface IStorage
    {

        public void Store(ItemScriptables item);
        public void RemoveItem(ItemScriptables item);
        public int GetAmount(ItemScriptables item);
        public int GetStorage();
    }
}
