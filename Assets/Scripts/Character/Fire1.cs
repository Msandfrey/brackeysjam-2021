using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Character
{
    public class Fire1 : MonoBehaviour
    {
        [SerializeField]
        private GameObject projectile;
        [SerializeField]
        private Transform spawnPoint;
        [SerializeField]
        private float LaunchForce = 1000;
        [SerializeField]
        private float ForceMultiplier = 1;
        [SerializeField]
        Rigidbody m_Rigidbody;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                GameObject projectileInstance = Instantiate(projectile, spawnPoint.position, spawnPoint.localRotation);
                m_Rigidbody = projectileInstance.GetComponent<Rigidbody>();
                m_Rigidbody.AddForce(spawnPoint.forward * LaunchForce * ForceMultiplier);
            }
        }

        public void FireBulletStraight(int damage)
        {
            GameObject projectileInstance = Instantiate(projectile, spawnPoint.position, spawnPoint.localRotation);
            projectileInstance.GetComponent<DamageBullets>().SetDamage(damage);
            projectileInstance.GetComponent<DamageBullets>().SetOwner(transform.parent.gameObject);
            m_Rigidbody = projectileInstance.GetComponent<Rigidbody>();
            m_Rigidbody.AddForce(spawnPoint.right * LaunchForce * ForceMultiplier);
        }

    }
}
