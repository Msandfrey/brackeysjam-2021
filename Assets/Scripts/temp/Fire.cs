using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public virtual void Shoot(int damage)
    {
        Debug.Log("Base shooting method");
    }
}
