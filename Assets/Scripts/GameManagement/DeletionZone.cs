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
            EnemyController enemyController = other.GetComponent<EnemyController>();
            if (enemyController)
            {
                enemyController.RemoveFromGame();
            }
        }
    }
}
