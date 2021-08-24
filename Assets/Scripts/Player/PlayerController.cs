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
        private Fire1 fireStraight1_1;

        //Jimmy Variables
        [SerializeField]
        private Fire2_2 fireStraight2_4;
        [SerializeField]
        private Fire2_2 fireStraight2_5;

        [SerializeField]
        private Fire3 fireStraight1_3;
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
                if(_fireMode == fireMode.One) fireStraight1_1.Shoot(damage);
                if (_fireMode == fireMode.Two) 
                {
                    fireStraight2_4.Shoot(damage);
                    fireStraight2_5.Shoot(damage);
                }
                if (_fireMode == fireMode.Three)
                {
                    fireStraight1_3.Shoot(damage);
                }
            }
        }

        void HandleDeath()
        {
            gameManager.EndGame();
        }
    }
}
