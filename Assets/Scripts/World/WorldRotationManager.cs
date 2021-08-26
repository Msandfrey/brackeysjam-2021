using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRotationManager : MonoBehaviour
{

    [Range(0,1f)]
    [SerializeField]
    private float eulerAnglesSpeed = 0.5f;

    [SerializeField]
    private Camera _camera; //Unity doesn't like "camera"
    private int spinCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(spinCount > 0)
        {
            transform.Rotate(new Vector3(0, 0, eulerAnglesSpeed));
            spinCount--;
        }
        else if(spinCount < 0)
        {
            transform.Rotate(new Vector3(0, 0, -eulerAnglesSpeed));
            spinCount++;
        }
        
    }


    public void SmoothRotate()
    {
        int sign = Random.Range(0,2);
        
        if (sign == 0)
        {
            spinCount = Random.Range(15, 91);
        }
        else
        {
            spinCount = Random.Range(-90, -14);
        }
        ChangeCamerSize();
    }

    public void ChangeCamerSize()
    {
        if(transform.eulerAngles.z >= 0)
        {
            if (transform.eulerAngles.z >= 0 && transform.eulerAngles.z < 90)
            {
                _camera.orthographicSize = 5 + transform.eulerAngles.z / 18;
            }
            else if (transform.eulerAngles.z >= 90 && transform.eulerAngles.z < 180)
            {
                _camera.orthographicSize = 10 - (transform.eulerAngles.z - 90) / 18;
            }
            else if (transform.eulerAngles.z >= 180 && transform.eulerAngles.z < 270)
            {
                _camera.orthographicSize = 5 + (transform.eulerAngles.z - 180) / 18;
            }
            else if (transform.eulerAngles.z >= 270 && transform.eulerAngles.z < 360)
            {
                _camera.orthographicSize = 10 - (transform.eulerAngles.z - 270) / 18;
            }
        }
        else
        {
            if (transform.eulerAngles.z <= 0 && transform.eulerAngles.z > -90)
            {
                _camera.orthographicSize = 5 - transform.eulerAngles.z / 18;
            }
            else if (transform.eulerAngles.z <= -90 && transform.eulerAngles.z > -180)
            {
                _camera.orthographicSize = 10 + (transform.eulerAngles.z + 90) / 18;
            }
            else if (transform.eulerAngles.z <= -180 && transform.eulerAngles.z > -270)
            {
                _camera.orthographicSize = 5 - (transform.eulerAngles.z + 180) / 18;
            }
            else if (transform.eulerAngles.z <= -270 && transform.eulerAngles.z > -360)
            {
                _camera.orthographicSize = 10 + (transform.eulerAngles.z + 270) / 18;
            }
        }
        
    }
}
