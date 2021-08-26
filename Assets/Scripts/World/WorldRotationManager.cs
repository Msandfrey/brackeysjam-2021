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
    [SerializeField]
    private float cameraRotationIncrement = 9;
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
        
        
        if (transform.eulerAngles.z >= 0 && transform.eulerAngles.z < 45)
        {
            _camera.orthographicSize = 5 + transform.eulerAngles.z / cameraRotationIncrement;
        }
        else if (transform.eulerAngles.z >= 45 && transform.eulerAngles.z < 135)
        {
            _camera.orthographicSize = 10;
        }
        else if (transform.eulerAngles.z >= 135 && transform.eulerAngles.z < 180)
        {
            _camera.orthographicSize = 10 - (transform.eulerAngles.z - 135) / cameraRotationIncrement;
        }
        else if (transform.eulerAngles.z >= 180 && transform.eulerAngles.z < 225)
        {
            _camera.orthographicSize = 5 + (transform.eulerAngles.z - 180) / cameraRotationIncrement;
        }
        else if (transform.eulerAngles.z >= 225 && transform.eulerAngles.z < 315)
        {
            _camera.orthographicSize = 10;
        }
        else if (transform.eulerAngles.z >= 315 && transform.eulerAngles.z < 360)
        {
            _camera.orthographicSize = 10 - (transform.eulerAngles.z - 315) / cameraRotationIncrement;
        }
        Debug.Log(transform.eulerAngles.z);
    }
}


