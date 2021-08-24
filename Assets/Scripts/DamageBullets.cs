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

    public void SetLayer(int newLayer)
    {
        layer = newLayer;
        gameObject.layer = layer;
        //only collide with 
        if (layer == 0) { Physics.IgnoreLayerCollision(1, 8); }
        else 
        {
            Physics.IgnoreLayerCollision(0, layer - 1);
            Physics.IgnoreLayerCollision(layer + 1, 8);
        } 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy") && !owner.tag.Equals("Enemy"))
        {
            other.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if(other.tag.Equals("Player") && !owner.tag.Equals("Player"))
        {
            other.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
