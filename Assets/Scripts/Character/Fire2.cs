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
        public override void Shoot(int damage)
        {
            GameObject projectileInstance1 = Instantiate(projectile, spawnPointTop.position, spawnPointTop.localRotation);
            projectileInstance1.GetComponent<DamageBullets>().SetDamage(damage);
            projectileInstance1.GetComponent<DamageBullets>().SetOwner(Player);
            m_Rigidbody = projectileInstance1.GetComponent<Rigidbody>();
            m_Rigidbody.AddForce(spawnPointTop.right * LaunchForce * ForceMultiplier);

            GameObject projectileInstance2 = Instantiate(projectile, spawnPointBot.position, spawnPointBot.localRotation);
            projectileInstance2.GetComponent<DamageBullets>().SetDamage(damage);
            projectileInstance2.GetComponent<DamageBullets>().SetOwner(Player);
            m_Rigidbody = projectileInstance2.GetComponent<Rigidbody>();
            m_Rigidbody.AddForce(spawnPointBot.right * LaunchForce * ForceMultiplier);
        }
    }
}
