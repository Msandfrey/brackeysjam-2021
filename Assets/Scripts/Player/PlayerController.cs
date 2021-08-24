using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Character;
using IndieWizards.GameManagement;

namespace IndieWizards.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private int damage = 1;
        [SerializeField]
        private Fire1 fireStraight;

        private Health health;
        private GameManager gameManager;
        // Start is called before the first frame update
        void Start()
        {
            gameManager = FindObjectOfType<GameManager>();
            health = GetComponent<Health>();
            health.onDeath += HandleDeath;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                fireStraight.FireBulletStraight(damage);
            }
        }

        void HandleDeath()
        {
            gameManager.EndGame();
        }
    }
}
