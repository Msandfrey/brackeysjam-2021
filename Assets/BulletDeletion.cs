using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDeletion : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Bullet")) { Destroy(other.gameObject); }
    }
}
