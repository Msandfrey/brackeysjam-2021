using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Character
{
    public class AllGuns : Fire
    {
        [SerializeField]
        private Fire[] gunList;

        public override void Shoot(int damageHealValue, bool isHealing, GameObject bulletToShoot)
        {
            foreach (Fire fire in gunList)
            {
                fire.Shoot(damageHealValue,isHealing,bulletToShoot);
            }
        }
    }
}