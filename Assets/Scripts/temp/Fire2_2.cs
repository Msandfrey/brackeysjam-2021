using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Character
{
    public class Fire2_2 : Fire
    {
        [SerializeField]
        private GameObject projectile;
        [SerializeField]
        private Transform spawnPoint4;
        [SerializeField]
        private Transform spawnPoint5;
        [SerializeField]
        private float LaunchForce = 1000;
        [SerializeField]
        private float ForceMultiplier = 1;
        Rigidbody m_Rigidbody;
        [SerializeField]
        private GameObject Player;

        public override void Shoot(int damageHealValue, bool isHealing, GameObject bulletToShoot)
        {
            GameObject projectileInstance4 = Instantiate(projectile, spawnPoint4.position, spawnPoint4.localRotation);
            projectileInstance4.GetComponent<Bullets>().SetDamage(damageHealValue);
            projectileInstance4.GetComponent<Bullets>().SetHealAmount(damageHealValue);
            projectileInstance4.GetComponent<Bullets>().SetOwner(Player);
            m_Rigidbody = projectileInstance4.GetComponent<Rigidbody>();
            m_Rigidbody.AddForce(spawnPoint4.right * LaunchForce * ForceMultiplier);

            GameObject projectileInstance5 = Instantiate(projectile, spawnPoint5.position, spawnPoint5.localRotation);
            projectileInstance5.GetComponent<Bullets>().SetDamage(damageHealValue);
            projectileInstance5.GetComponent<Bullets>().SetHealAmount(damageHealValue);
            projectileInstance5.GetComponent<Bullets>().SetOwner(Player);
            m_Rigidbody = projectileInstance5.GetComponent<Rigidbody>();
            m_Rigidbody.AddForce(spawnPoint5.right * LaunchForce * ForceMultiplier);
        }

    }
}