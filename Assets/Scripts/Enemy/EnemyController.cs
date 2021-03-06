using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.GameManagement;
using IndieWizards.Character;
using IndieWizards.Animation;
using IndieWizards.Player;

namespace IndieWizards.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        public enum EnemyType { Zero, One, Two, Three };
        public EnemyType currentEnemyType;
        [Header("Stats")]
        [SerializeField]
        private int scoreValue = 10;
        [SerializeField]
        private float moveSpeed = 5;
        [SerializeField]
        private int bulletDamage = 1;
        [SerializeField]
        [Tooltip("Higher number is slower rate.")]
        private float fireRate = .5f;
        private float lastTimeChanged;
        [SerializeField]
        private float cooldownOnChange = 1f;

        [Header("ShipColors")]
        [SerializeField]
        private Color form0Color;
        [SerializeField]
        private Color form1Color;
        [SerializeField]
        private Color form2Color;
        [SerializeField]
        private Color form3Color;

        [Header("Components")]
        private GameManager gameManager;
        [SerializeField]
        private Fire[] gunList;
        [SerializeField]
        private GameObject[] bulletList;
        private GameObject currentBullet;
        private Fire currentGun;
        private EnemyAnimationController enemyAnimationController;
        private Health health;
        private AudioManager audioManager;
        // Start is called before the first frame update
        void Start()
        {
            gameManager = FindObjectOfType<GameManager>();
            enemyAnimationController = GetComponent<EnemyAnimationController>();
            health = GetComponent<Health>();
            health.onDeath += HandleDeath;
            health.onDamage += HandleDamage;
            audioManager = FindObjectOfType<AudioManager>();
            HandleChange((int)currentEnemyType);
            //continually fire
            StartCoroutine(FireWeapon());

        }

        // Update is called once per frame
        void Update()
        {
            GetComponent<Rigidbody>().velocity = transform.forward * moveSpeed;
        }

        void HandleDamage()
        {
            if(lastTimeChanged - Time.time <= cooldownOnChange) { HandleChange(); }
        }

        public void HandleChange(int type = -1)
        {
            ChangeType(type);
            ChangeGun();
            ChangeBullets();
            ChangeColor();
            //ChangeMovement();
            //set cooldown for change
            lastTimeChanged = Time.time;
        }

        void ChangeType(int type)
        {
            if(type == -1)
            {
                currentEnemyType = (EnemyType)Random.Range(0, 3);
            }
            else
            {
                currentEnemyType = (EnemyType)type;
            }
            //animation for change
            enemyAnimationController.SetForm((int)currentEnemyType);
            audioManager.PlayTransformationSound();
        }

        void ChangeGun()
        {
            currentGun = gunList[Random.Range(0, 5)]; 
        }

        void ChangeBullets()
        {
            switch (currentEnemyType)
            {
                case EnemyType.Zero://friendly heals
                    currentBullet = bulletList[1];
                    break;
                case EnemyType.One://enemy damages
                    currentBullet = bulletList[0];
                    break;
                case EnemyType.Two://weird spins
                    currentBullet = bulletList[2];
                    break;
                case EnemyType.Three://weird spins
                    currentBullet = bulletList[2];
                    break;
                default://default damages
                    currentBullet = bulletList[0];
                    break;
            }
        }

        void ChangeColor()
        {
            Material mat = GetComponent<SkinnedMeshRenderer>().material;
            switch (currentEnemyType)
            {
                case EnemyType.Zero:
                    mat.color = form0Color;
                    break;
                case EnemyType.One:
                    mat.color = form1Color;
                    break;
                case EnemyType.Two:
                    mat.color = form2Color;
                    break;
                case EnemyType.Three:
                    mat.color = form3Color;
                    break;
                default:
                    mat.color = form0Color;
                    break;
            }
        }

        IEnumerator FireWeapon()
        {
            yield return new WaitForSeconds(fireRate);
            audioManager.ShootingSound2();
            currentGun.Shoot(bulletDamage, false, currentBullet);//second damage needs to be a heal
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
            audioManager.PlayShipExplosionSound();
            gameManager.AddToScore(scoreValue);
            gameManager.RemoveEnemy(this.gameObject);
            Destroy(this.gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals("Player"))
            {
                other.GetComponent<Health>().TakeDamage(bulletDamage);
                GetComponent<Health>().TakeDamage(1);
                other.GetComponent<Spin>().BeASpin();
            }
        }
    }
}
