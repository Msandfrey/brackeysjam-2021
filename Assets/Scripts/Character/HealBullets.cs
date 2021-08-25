using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Character;

namespace IndieWizards.Character
{
    public class HealBullets : Bullets
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other != null && owner != null)
            {
                if (other.tag.Equals("Enemy") && !owner.tag.Equals("Enemy"))
                {
                    other.GetComponent<Health>().RestoreHealth(amountHealed);
                    Destroy(gameObject);
                }
                if (other.tag.Equals("Player") && !owner.tag.Equals("Player"))
                {
                    other.GetComponent<Health>().RestoreHealth(amountHealed);
                    Destroy(gameObject);
                    
                }
            }
        }
    }
}
