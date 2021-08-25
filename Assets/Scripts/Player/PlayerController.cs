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
        private enum FireMode {One,Two,Three,Four,Five};
        [SerializeField]
        private FireMode fireMode = FireMode.One;
        //
        
        [SerializeField]
        private int damage = 1;
        [SerializeField]
        private Fire1 fireStraight1;

        //Jimmy Variables
        [SerializeField]
        private Fire2 fireStraight2; 

        [SerializeField]
        private Fire3 fireStraight3;

        [SerializeField]
        private Fire4 fireStraight4;
        [SerializeField]
        private Fire5 fireStraight5;
        [SerializeField]
        private Fire[] fireModes;
        private Fire currentFireMode;
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
                if (fireMode == FireMode.One) fireStraight1.Shoot(damage);
                if (fireMode == FireMode.Two)  fireStraight2.Shoot(damage);
                if (fireMode == FireMode.Three) fireStraight3.Shoot(damage);
                if (fireMode == FireMode.Four) fireStraight4.Shoot(damage);
                if (fireMode == FireMode.Five) fireStraight5.Shoot(damage);
            }
        }

        void HandleDeath()
        {
            gameManager.EndGame();
        }

        public void HandleChange(int type = -1)
        {

        }
        void ChangeFireMode()
        {

        }
    }
}
