using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Character;

public class DamageBullets : MonoBehaviour
{
    [SerializeField]
    private int damage;
    private int layer;
    [SerializeField]
    private GameObject owner;
    
    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }

    public void SetOwner(GameObject ownerObject)
    {
        owner = ownerObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other != null && owner != null)
        {
            if (other.tag.Equals("Enemy") && !owner.tag.Equals("Enemy"))
            {
                other.GetComponent<Health>().TakeDamage(damage);
                Destroy(gameObject);
            }
            if (other.tag.Equals("Player") && !owner.tag.Equals("Player"))
            {
                other.GetComponent<Health>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
