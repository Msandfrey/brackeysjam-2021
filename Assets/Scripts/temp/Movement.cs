using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    private void Move()
    {
        //Up and Down Movements
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w"))
        {
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
        {
            transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, 0, -90);
        }

        //Left and Right Movements
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
        {
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
