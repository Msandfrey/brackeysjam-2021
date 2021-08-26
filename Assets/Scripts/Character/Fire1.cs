using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Character
{
    public class Fire1 : Fire
    {
        [SerializeField]
        private Transform spawnPoint;
        [SerializeField]
        private float LaunchForce = 1000;
        [SerializeField]
        private float ForceMultiplier = 1;
        Rigidbody m_Rigidbody;
        [SerializeField]
        private GameObject Player;

        public override void Shoot(int damageHealValue, bool isHealing, GameObject bulletToShoot)
        {
            GameObject projectileInstance = Instantiate(bulletToShoot, spawnPoint.position, spawnPoint.localRotation);
            projectileInstance.GetComponent<Bullets>().SetDamage(damageHealValue);
            projectileInstance.GetComponent<Bullets>().SetHealAmount(damageHealValue);
            projectileInstance.GetComponent<Bullets>().SetOwner(Player);
            m_Rigidbody = projectileInstance.GetComponent<Rigidbody>();
            m_Rigidbody.AddForce(spawnPoint.right * LaunchForce * ForceMultiplier);
        }

    }
}
