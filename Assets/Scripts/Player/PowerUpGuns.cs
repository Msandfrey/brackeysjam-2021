using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Player
{
    public class PowerUpGuns : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed = 5f;
        // Start is called before the first frame update
        void Start()
        {
            GetComponent<Rigidbody>().velocity = -moveSpeed * transform.right;
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals("Player"))
            {
                other.GetComponent<PlayerController>().ChangeFireMode();
                Destroy(gameObject);
            }
        }
    }
}