using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Character
{
    public class Bullets : MonoBehaviour
    {
        [SerializeField]
        protected GameObject owner;
        [SerializeField]
        protected int amountHealed;
        [SerializeField]
        protected int damage;

        public void SetDamage(int newDamage)
        {
            damage = newDamage;
        }

        public void SetHealAmount(int newHeal)
        {
            amountHealed = newHeal;
        }

        public void SetOwner(GameObject ownerObject)
        {
            owner = ownerObject;
        }
    }
}
