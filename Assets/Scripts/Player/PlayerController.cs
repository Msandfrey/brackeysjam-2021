using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Character;
using IndieWizards.GameManagement;

namespace IndieWizards.Player
{
    public class PlayerController : MonoBehaviour
    {
        // Jimmy Variables
        private enum fireMode {
            One,
            Two,
            Three,
            Four,
            Five
        };
        [SerializeField]
        private fireMode _fireMode = fireMode.One;
        //
        
        [SerializeField]
        private int damage = 1;
        [SerializeField]
        private Fire1 fireStraight1;

        //Jimmy Variables
        [SerializeField]
        private Fire2_2 fireStraight2; //It's fire2, just didn't want to change other script yet

        [SerializeField]
        private Fire3 fireStraight3;

        [SerializeField]
        private Fire4 fireStraight4;
        [SerializeField]
        private Fire5 fireStraight5;
        //

        
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
                if(_fireMode == fireMode.One) fireStraight1.Shoot(damage);
                if (_fireMode == fireMode.Two)  fireStraight2.Shoot(damage);
                if (_fireMode == fireMode.Three) fireStraight3.Shoot(damage);
                if (_fireMode == fireMode.Four) fireStraight4.Shoot(damage);
                if (_fireMode == fireMode.Five) fireStraight5.Shoot(damage);
            }
        }

        void HandleDeath()
        {
            gameManager.EndGame();
        }
    }
}
