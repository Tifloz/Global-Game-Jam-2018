using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float damage = 4.5f;

    private void Start()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Wraith"))
        {
            Debug.Log("Collided with " + other.gameObject.name + " !");
            var wraith = other.gameObject.GetComponent<WraithActionScript>();
            wraith.health -= damage;
            if (wraith.health <= 0)
                Destroy(wraith.gameObject);
            Destroy(gameObject);
        }
    }

}
