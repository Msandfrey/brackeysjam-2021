using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Player;

namespace IndieWizards.Character
{
    public class SpinBullets : Bullets
    {
        private AudioManager audioManager;

        private void Start()
        {
            audioManager = FindObjectOfType<AudioManager>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other != null && owner != null)
            {
                if (other.tag.Equals("Player") && !owner.tag.Equals("Player"))
                {
                    other.GetComponent<Spin>().BeASpin();
                    Destroy(gameObject);
                    
                }
                return;
            }

            if (other.tag.Equals("Player"))
            {
                other.GetComponent<Health>().TakeDamage(damage);
                audioManager.PlayPlayerHitSound();
                Destroy(gameObject);
            }
        }
    }
}
