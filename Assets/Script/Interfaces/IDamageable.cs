using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anargo
{
    public interface IDamageable
    {
        public void TakeDamage(int damage);
        public void Dies();
        public void Heal(int amount);
    }
}
