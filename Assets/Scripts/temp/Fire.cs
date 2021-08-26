using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public virtual void Shoot(int damageHealValue, bool isHealing, GameObject bulletToShoot)
    {
        Debug.Log("Base shooting method");
    }
}
