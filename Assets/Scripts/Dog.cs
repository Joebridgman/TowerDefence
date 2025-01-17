using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{

    public Waypoint target;
    public float speed;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null) {
            transform.position += (transform.position - target.transform.position).normalized * -speed;
        }
        else {
            Destroy(gameObject);
            //take lives off the player
        }

        if (health <= 0) { 
            Destroy(gameObject);
            //death animation
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Waypoint") {
            target = collision.gameObject.GetComponent<Waypoint>().nextWaypoint;
        }
    }
}
