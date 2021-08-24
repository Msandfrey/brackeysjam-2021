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
        [SerializeField]
        Rigidbody m_Rigidbody;
        [SerializeField]
        private float fireRate = 0.1f;
        [SerializeField]
        private float lastTime = 0f;
        [SerializeField]
        private float sineValue;
        [SerializeField]
        private float shootingDuration = 0f;
        // Start is called before the first frame update
        void Start()
        {
            lastTime = Time.time;
        }

        // Update is called once per frame
        void Update()
        {
            float waitTime = Time.time - lastTime;
        
            Vector3 thisRotation = this.gameObject.transform.rotation.eulerAngles;
            if (Input.GetKey(KeyCode.Space))
            {
                shootingDuration += Time.deltaTime;
                transform.Rotate(new Vector3(0, 0, .085f * Mathf.Cos(shootingDuration)));
                sineValue = Mathf.Sin(shootingDuration);

                if(waitTime > fireRate)
                {
                    GameObject projectileInstance = Instantiate(projectile, spawnPoint.position, spawnPoint.localRotation);
                    m_Rigidbody = projectileInstance.GetComponent<Rigidbody>();
                    m_Rigidbody.AddForce(spawnPoint.right * LaunchForce * ForceMultiplier);

                    lastTime = Time.time;
                }
            }
        
        
        
            if(waitTime > 1.5f)
            {
                transform.rotation = Quaternion.identity;
                shootingDuration = 0;
            }
        }

        public override void Shoot(int damage)
        {

        }
    }
}
