using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Character
{
    public class Fire3 : Fire
    {
        [SerializeField]
        private GameObject projectile;
        [SerializeField]
        private Transform spawnPoint1;
        [SerializeField]
        private Transform spawnPoint2;
        [SerializeField]
        private Transform spawnPoint3;
        [SerializeField]
        private float LaunchForce = 1000;
        [SerializeField]
        private float ForceMultiplier = 1;
        Rigidbody m_Rigidbody;
        [SerializeField]
        private GameObject Player;
        

        public override void Shoot(int damage, GameObject bulletToShoot)
        {
            spawnPoint2.Rotate(0, -15f, 0);
            spawnPoint3.Rotate(0, 15f, 0);
            
            GameObject projectileInstance1 = Instantiate(bulletToShoot, spawnPoint1.position, spawnPoint1.localRotation);
            projectileInstance1.GetComponent<DamageBullets>().SetDamage(damage);
            projectileInstance1.GetComponent<DamageBullets>().SetOwner(Player);
            m_Rigidbody = projectileInstance1.GetComponent<Rigidbody>();
            m_Rigidbody.AddForce(spawnPoint1.right * LaunchForce * ForceMultiplier);

            GameObject projectileInstance2 = Instantiate(bulletToShoot, spawnPoint2.position, spawnPoint2.localRotation);
            projectileInstance2.GetComponent<DamageBullets>().SetDamage(damage);
            projectileInstance2.GetComponent<DamageBullets>().SetOwner(Player);
            m_Rigidbody = projectileInstance2.GetComponent<Rigidbody>();
            m_Rigidbody.AddForce(spawnPoint2.right * LaunchForce * ForceMultiplier);

            GameObject projectileInstance3 = Instantiate(bulletToShoot, spawnPoint3.position, spawnPoint3.localRotation);
            projectileInstance3.GetComponent<DamageBullets>().SetDamage(damage);
            projectileInstance3.GetComponent<DamageBullets>().SetOwner(Player);
            m_Rigidbody = projectileInstance3.GetComponent<Rigidbody>();
            m_Rigidbody.AddForce(spawnPoint3.right * LaunchForce * ForceMultiplier);

            spawnPoint2.Rotate(0, 15f, 0);
            spawnPoint3.Rotate(0, -15f, 0);
            
        }

    }
}
