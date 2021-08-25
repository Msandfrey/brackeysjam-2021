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

        public override void Shoot(int damage)
        {
            GameObject projectileInstance4 = Instantiate(projectile, spawnPoint4.position, spawnPoint4.localRotation);
            projectileInstance4.GetComponent<DamageBullets>().SetDamage(damage);
            projectileInstance4.GetComponent<DamageBullets>().SetOwner(transform.parent.gameObject);
            m_Rigidbody = projectileInstance4.GetComponent<Rigidbody>();
            m_Rigidbody.AddForce(spawnPoint4.right * LaunchForce * ForceMultiplier);

            GameObject projectileInstance5 = Instantiate(projectile, spawnPoint5.position, spawnPoint5.localRotation);
            projectileInstance5.GetComponent<DamageBullets>().SetDamage(damage);
            projectileInstance5.GetComponent<DamageBullets>().SetOwner(transform.parent.gameObject);
            m_Rigidbody = projectileInstance5.GetComponent<Rigidbody>();
            m_Rigidbody.AddForce(spawnPoint5.right * LaunchForce * ForceMultiplier);
        }

    }
}