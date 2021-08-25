using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Character;
using IndieWizards.GameManagement;

namespace IndieWizards.Player
{
    public class PlayerController : MonoBehaviour
    {
        private enum FireMode {One,Two,Three,Four,Five};
        [SerializeField]
        private FireMode fireMode = FireMode.One;
        
        [SerializeField]
        private int damage = 1;
        [SerializeField]
        private Fire[] fireModes;
        private Fire currentFireMode;

        private Health health;
        private GameManager gameManager;
        [SerializeField]
        private Color shipColor;
        // Start is called before the first frame update
        void Start()
        {
            GetComponent<MeshRenderer>().material.color = shipColor;
            gameManager = FindObjectOfType<GameManager>();
            health = GetComponent<Health>();
            health.onDeath += HandleDeath;
            ChangeFireMode();
        }

        // Update is called once per frame
        void Update()
        {
            if(currentFireMode != fireModes[(int)fireMode]) ChangeFireMode(); //should be in trigger when implemented
            if (Input.GetKeyDown(KeyCode.Space)) currentFireMode.Shoot(damage);
        }

        void HandleDeath()
        {
            gameManager.EndGame();
        }

        void ChangeFireMode()
        {
            currentFireMode = fireModes[(int)fireMode];
        }
    }
}
