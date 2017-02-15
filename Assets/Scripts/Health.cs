using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float health = 100;

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DestoryObject();
        }
    }

    public void DestoryObject()
    {
        Destroy(gameObject);
    }
}
