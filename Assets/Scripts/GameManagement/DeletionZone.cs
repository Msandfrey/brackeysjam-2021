using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Enemy;

namespace IndieWizards.GameManagement
{
    public class DeletionZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            //delete enemy so wave can end
            if (other.tag.Equals("Bullet"))
            {
                Destroy(other.gameObject);
            }
            if (other.tag.Equals("Enemy")) { other.GetComponent<EnemyController>().RemoveFromGame(); }
            
        }
    }
}
