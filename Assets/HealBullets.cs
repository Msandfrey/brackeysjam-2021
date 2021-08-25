using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Character;

public class HealBullets : MonoBehaviour
{
    [SerializeField]
    private int amountHealed;
    private int layer;
    [SerializeField]
    private GameObject owner;

    public void SetHealAmount(int newHeal)
    {
        amountHealed = newHeal;
    }

    public void SetOwner(GameObject ownerObject)
    {
        owner = ownerObject;
    }

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
