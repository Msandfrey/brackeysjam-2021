using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.GameManagement;
using IndieWizards.Character;

namespace IndieWizards.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        public enum EnemyType { One, Two, Three, Four };
        public EnemyType currentEnemyType;

        [SerializeField]
        private int scoreValue = 10;
        [SerializeField]
        private float speed = 5;
        [SerializeField]
        private int bulletDamage = 1;
        [SerializeField]
        [Tooltip("Higher number is slower rate.")]
        private float fireRate = .5f;
        private float lastTimeChanged;
        [SerializeField]
        private float cooldownOnChange = 1f;
        private GameManager gameManager;
        [SerializeField]
        private Fire[] gunList;
        private Fire currentGun;
        private Health health;
        // Start is called before the first frame update
        void Start()
        {
            gameManager = FindObjectOfType<GameManager>();
            health = GetComponent<Health>();
            health.onDeath += HandleDeath;
            health.onDamage += HandleDamage;

            HandleChange((int)currentEnemyType);

            //continually fire
            StartCoroutine(FireWeapon());

        }

        // Update is called once per frame
        void Update()
        {
            GetComponent<Rigidbody>().velocity = transform.right * -speed;
        }

        void HandleDamage()
        {
            if(Time.time - lastTimeChanged <= cooldownOnChange) { HandleChange(); }
        }

        public void HandleChange(int type = -1)
        {
            ChangeType(type);
            ChangeGun();
            //ChangeMovement();
            //set cooldown for change
            lastTimeChanged = Time.time;
        }

        void ChangeType(int type)
        {
            if(type == -1)
            {
                currentEnemyType = EnemyType.One;//(EnemyType)Random.Range(0, 3);TODO
            }
            else
            {
                currentEnemyType = (EnemyType)type;
            }
            //animation for change
        }

        void ChangeGun()
        {
            currentGun = gunList[(int)currentEnemyType];

        }

        IEnumerator FireWeapon()
        {
            yield return new WaitForSeconds(fireRate);
            currentGun.Shoot(bulletDamage);
            StartCoroutine(FireWeapon());
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
