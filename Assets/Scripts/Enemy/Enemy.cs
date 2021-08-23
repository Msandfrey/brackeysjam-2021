using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.GameManagement;

namespace IndieWizards.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private bool isDead = false;
        private GameManager levelManager;
        // Start is called before the first frame update
        void Start()
        {
            levelManager = FindObjectOfType<GameManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (isDead)
            {
                levelManager.RemoveEnemy(this.gameObject);
                Destroy(this);
            }
        }
    }
}
