using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Character
{
    public class FireSpiral : Fire
    {
        [SerializeField]
        private GameObject projectile;
        [SerializeField]
        private Transform spawnPoint;
        [SerializeField]
        private float LaunchForce = 1000;
        [SerializeField]
        private float ForceMultiplier = 1;
        Rigidbody m_Rigidbody;
        private float lastTime = 0f;
        private float sineValue;
        private float shootingDuration = 0f;
        [SerializeField]
        private GameObject Player;
        
        // Start is called before the first frame update
        void Start()
        {
            lastTime = Time.time;
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public override void Shoot(int damageHealValue, bool isHealing, GameObject bulletToShoot)
        {
            // waitTime = Time.time - lastTime;

            // Vector3 thisRotation = this.gameObject.transform.rotation.eulerAngles;
            // shootingDuration += Time.deltaTime;
            

            
            GameObject projectileInstance = Instantiate(bulletToShoot, spawnPoint.position, spawnPoint.localRotation);
            projectileInstance.GetComponent<Bullets>().SetDamage(damageHealValue);
            projectileInstance.GetComponent<Bullets>().SetHealAmount(damageHealValue);
            projectileInstance.GetComponent<Bullets>().SetOwner(Player);
            m_Rigidbody = projectileInstance.GetComponent<Rigidbody>();
            m_Rigidbody.AddForce(spawnPoint.right * LaunchForce * ForceMultiplier);

            
            transform.Rotate(new Vector3(0, 0, 5 * Mathf.Cos(shootingDuration)));
            shootingDuration += 1/360;

            // if (waitTime > 1.5f)
            // {
            //     transform.rotation = Quaternion.identity;
            //     shootingDuration = 0;
            // }
        }
    }
}
