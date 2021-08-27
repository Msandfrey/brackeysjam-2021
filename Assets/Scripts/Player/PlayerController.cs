using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Character;
using IndieWizards.Animation;
using IndieWizards.GameManagement;

namespace IndieWizards.Player
{
    public class PlayerController : MonoBehaviour
    {
        private enum FireMode {One,Two,Three,Four,Five};
        //[SerializeField]
        //private FireMode fireMode = FireMode.One;

        [SerializeField]
        private int damage = 1;
        [SerializeField]
        private Fire[] fireModes;
        private Fire currentFireMode;

        [SerializeField]
        private GameObject bullet;
        private Health health;
        private GameManager gameManager;
        [SerializeField]
        EnemyAnimationController animationController;

        [Header("Ship Colors")]
        [SerializeField]
        private Color form0;
        [SerializeField]
        private Color form1;
        [SerializeField]
        private Color form2;
        [SerializeField]
        private Color form3;

        private AudioManager audioManager;
        // Start is called before the first frame update
        void Start()
        {
            animationController = GetComponent<EnemyAnimationController>();
            GetComponent<SkinnedMeshRenderer>().material.color = form0;
            gameManager = FindObjectOfType<GameManager>();
            audioManager = FindObjectOfType<AudioManager>();
            health = GetComponent<Health>();
            health.onDeath += HandleDeath;
            ChangeFireMode(0);
        }

        // Update is called once per frame
        void Update()
        {
            Shooting();
        }

        public void Shooting()
        {
            //if(currentFireMode != fireModes[(int)fireMode]) ChangeFireMode(); //should be in trigger when implemented
            if (Input.GetKeyDown(KeyCode.Space))
            {
                audioManager.ShootingSound2();
                currentFireMode.Shoot(damage, false, bullet);//second damage needs to be heal TODO
            }
        }
        void HandleDeath()
        {
            audioManager.PlayShipExplosionSound();
            gameManager.EndGame();
        }

        public void ChangeFireMode(int mode = -1)
        {
            if(mode == -1)
            {
                currentFireMode = fireModes[Random.Range(0, 4)];
            }
            else
            {
                currentFireMode = fireModes[mode];
            }
        }

        public void ChangeForm()
        {
            int newForm = Random.Range(0, 3);
            animationController.SetForm(newForm);
            switch (newForm)
            {
                case 0:
                    GetComponent<SkinnedMeshRenderer>().material.color = form0;
                    break;
                case 1:
                    GetComponent<SkinnedMeshRenderer>().material.color = form1;
                    break;
                case 2:
                    GetComponent<SkinnedMeshRenderer>().material.color = form2;
                    break;
                case 3:
                    GetComponent<SkinnedMeshRenderer>().material.color = form3;
                    break;
                default:
                    GetComponent<SkinnedMeshRenderer>().material.color = form0;
                    break;
            }
        }

        public void SetDamage()
        {
            damage++;
        }
    }
}
