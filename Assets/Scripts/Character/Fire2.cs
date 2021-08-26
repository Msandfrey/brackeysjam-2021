using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Character
{
    public class Fire2 : Fire
    {
        [SerializeField]
        private GameObject projectile;
        [SerializeField]
        private Transform spawnPointTop;
        [SerializeField]
        private Transform spawnPointBot;
        [SerializeField]
        private float LaunchForce = 1000;
        [SerializeField]
        private float ForceMultiplier = 1;
        Rigidbody m_Rigidbody;
        [SerializeField]
        private GameObject Player;
        public override void Shoot(int damageHealValue, bool isHealing, GameObject bulletToShoot)
        {
            GameObject projectileInstance1 = Instantiate(bulletToShoot, spawnPointTop.position, spawnPointTop.localRotation);
            projectileInstance1.GetComponent<Bullets>().SetDamage(damageHealValue);
            projectileInstance1.GetComponent<Bullets>().SetHealAmount(damageHealValue);
            projectileInstance1.GetComponent<Bullets>().SetOwner(Player);
            m_Rigidbody = projectileInstance1.GetComponent<Rigidbody>();
            m_Rigidbody.AddForce(spawnPointTop.right * LaunchForce * ForceMultiplier);

            GameObject projectileInstance2 = Instantiate(bulletToShoot, spawnPointBot.position, spawnPointBot.localRotation);
            projectileInstance2.GetComponent<Bullets>().SetDamage(damageHealValue);
            projectileInstance2.GetComponent<Bullets>().SetHealAmount(damageHealValue);
            projectileInstance2.GetComponent<Bullets>().SetOwner(Player);
            m_Rigidbody = projectileInstance2.GetComponent<Rigidbody>();
            m_Rigidbody.AddForce(spawnPointBot.right * LaunchForce * ForceMultiplier);
        }
    }
}
