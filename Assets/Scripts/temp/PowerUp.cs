using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.GameManagement;
using IndieWizards.Character;

namespace IndieWizards.Player
{
    public class PowerUp : MonoBehaviour
    {
        
        GameManager gameManager;
        [SerializeField]
        private float moveSpeed = 5;
        private enum PowerUpgrade {OneShot,DoubleShot,TripleShot,QuadShot,PentaShot};

        [SerializeField]
        private PowerUpgrade Upgrade;

        [SerializeField]
        private GameObject _camera; //Unity doesn't like "camera"
        [SerializeField]
        private AudioManager audioManager;

        void Start()
        {
            gameManager = FindObjectOfType<GameManager>();
            _camera = FindObjectOfType<Camera>().gameObject;
            audioManager = FindObjectOfType<AudioManager>();
        }

        // Update is called once per frame
        void Update()
        {
            GetComponent<Rigidbody>().velocity = transform.forward * moveSpeed;
        }

        private void OnTriggerEnter(Collider other) 
        {
            if(other.tag == "Player") 
            {
                PlayerController player = other.gameObject.GetComponent<PlayerController>();
                player.ChangeFireMode(); //(int)Upgrade need to paste this inside once i can add it in player controller
                Destroy(this.gameObject, 0.1f);
                RemoveFromGame();
                _camera.GetComponent<WorldRotationManager>().SmoothRotate();

                Health health = other.gameObject.GetComponent<Health>();
                audioManager.PlayHealingSound();
                health.RestoreHealth(health.maxHitPoints);
            }
        }

        public void RemoveFromGame()
        {
            gameManager.RemoveEnemy(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}