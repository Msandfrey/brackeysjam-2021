using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Player
{
    public class Movement : MonoBehaviour
    {
        [SerializeField]
        private float speed = 5f;
        // Start is called before the first frame update
        void Start()
        {
            //transform.rotation = Quaternion.identity;
            transform.position = new Vector3(-6f,0f,0f);
        }

        // Update is called once per frame
        void Update()
        {
            if(transform.position.y > 4.2f)
            {
                transform.position =  new Vector3(transform.position.x, 4.2f, 0);
            }
            if (transform.position.y < -4.2f)
            {
                transform.position = new Vector3(transform.position.x, -4.2f, 0);
            }
            Move();
        }


        private void Move()
        {
            //Up and Down Movements
            if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w"))
            {
                transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
            {
                transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
            }

            //Left and Right Movements
            // if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
            // {
            //     transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
            // }
            // if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
            // {
            //     transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            // }
        }
    }
}
