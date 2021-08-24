using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.GameManagement;
using IndieWizards.Character;

namespace IndieWizards.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        public enum EnemyType { One, Two, Three };
        public EnemyType currentEnemyType;

        [SerializeField]
        private int scoreValue = 10;
        [SerializeField]
        private float speed = 5;
        [SerializeField]
        private bool isDead = false;
        private GameManager gameManager;
        private Health health;
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
            GetComponent<Rigidbody>().velocity = transform.right * -speed;
            //for testing
            if (isDead)
            {
                HandleDeath();
            }
        }

        public void ChangeType()
        {
            currentEnemyType = (EnemyType)Random.Range(0, 2);
            //animation for change
            //change the way it fires
            //set cooldown for change
        }

        public void RemoveFromGame()//handles death on moving off screen
        {
            //gameManager.AddToScore(scoreValue);//for testing score
            gameManager.RemoveEnemy(this.gameObject);
            Destroy(this.gameObject);
        }

        void HandleDeath()//handles death on no hp to get points
        {
            gameManager.AddToScore(scoreValue);
            gameManager.RemoveEnemy(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
