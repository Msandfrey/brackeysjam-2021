using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Character;

namespace IndieWizards.Character
{
    public class HealBullets : Bullets
    {
        private AudioManager audioManager;

        private void Start()
        {
            audioManager = FindObjectOfType<AudioManager>();
        }        
        private void OnTriggerEnter(Collider other)
        {
            if (other != null && owner != null)
            {
                if (other.tag.Equals("Enemy") && !owner.tag.Equals("Enemy"))
                {
                    other.GetComponent<Health>().RestoreHealth(amountHealed);
                    audioManager.PlayHealingSound();
                    Destroy(gameObject);
                }
                if (other.tag.Equals("Player") && !owner.tag.Equals("Player"))
                {
                    other.GetComponent<Health>().RestoreHealth(amountHealed);
                    audioManager.PlayHealingSound();
                    Destroy(gameObject);
                }
                return;
            }

            if (other.tag.Equals("Player"))
            {
                other.GetComponent<Health>().RestoreHealth(amountHealed);
                audioManager.PlayHealingSound();
                Destroy(gameObject);
            }
        }
    }
}
