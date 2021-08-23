using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire2 : MonoBehaviour
{
    public GameObject projectile;
    public Transform spawnPoint;
    public float LaunchForce = 1000;
    public float ForceMultiplier = 1;
    Rigidbody m_Rigidbody;
    public float fireRate = 0.1f;
    public float lastTime = 0f;
    public bool shotToTheLeft = false; 
    public float sineValue;
    public float shootingDuration = 0f;
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
            transform.Rotate(new Vector3(0, 0, .25f * Mathf.Cos(shootingDuration)));
            sineValue = Mathf.Sin(shootingDuration);

            if(waitTime > fireRate)
            {
                GameObject projectileInstance = Instantiate(projectile, spawnPoint.position, spawnPoint.localRotation);
                m_Rigidbody = projectileInstance.GetComponent<Rigidbody>();
                m_Rigidbody.AddForce(spawnPoint.right * LaunchForce * ForceMultiplier);

                lastTime = Time.time;
            }
        }
        
        
        
        if(waitTime > 2f)
        {
            transform.rotation = Quaternion.identity;
            shootingDuration = 0;
        }
    }
}
