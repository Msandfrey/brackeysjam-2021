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

        public override void Shoot(int damage, GameObject bulletToShoot)
        {
            GameObject projectileInstance = Instantiate(bulletToShoot, spawnPoint.position, spawnPoint.localRotation);
            projectileInstance.GetComponent<DamageBullets>().SetDamage(damage);
            projectileInstance.GetComponent<DamageBullets>().SetOwner(Player);
            m_Rigidbody = projectileInstance.GetComponent<Rigidbody>();
            m_Rigidbody.AddForce(spawnPoint.right * LaunchForce * ForceMultiplier);
        }

    }
}
