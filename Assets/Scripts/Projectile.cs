using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    public GameObject target;
    public int speed;
    public float lifetime;
    public int damage;
    public float currentLifetime;

    // Update is called once per frame
    void Update()
    {
        currentLifetime += Time.deltaTime;

        if (target != null) {
            transform.position += (transform.position - target.transform.position).normalized * -speed;
        }

        if (currentLifetime > lifetime) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Dog") {
            collision.gameObject.GetComponent<Dog>().health -= damage;
            Debug.Log("Hit from " + gameObject.name + " for " + damage + " damage.");
        }
    }
}
