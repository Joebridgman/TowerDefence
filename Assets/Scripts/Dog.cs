using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{

    public Waypoint target;
    public float speed;
    public int health;
    public Sprite defaultSprite;
    public Sprite hurtSprite;
    public float hurtTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hurtTimer += Time.deltaTime;

        if (target != null) {
            transform.position += (transform.position - target.transform.position).normalized * -speed;
            if (Math.Pow(transform.position.x - target.transform.position.x, 2) +
            Math.Pow(transform.position.y - target.transform.position.y, 2) < 0.01) {
                target = target.nextWaypoint;
            }
        }
        else {
            Destroy(gameObject);
            //take lives off the player
        }

        if (health <= 0) { 
            Destroy(gameObject);
            //death animation
        }

        if (hurtTimer > 0.5) {
            GetComponent<SpriteRenderer>().sprite = defaultSprite;
            GetComponent<SpriteRenderer>().color = Color.white;
        }       
    }
}
