using System;
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
            var dogObject = collision.gameObject.GetComponent<Dog>();
            dogObject.health -= damage;
            dogObject.hurtTimer = 0;
            dogObject.GetComponent<SpriteRenderer>().color = Color.red;
            dogObject.GetComponent<SpriteRenderer>().sprite = dogObject.hurtSprite;
            Debug.Log("Hit from " + gameObject.name + " for " + damage + " damage.");
        }
    }
}
