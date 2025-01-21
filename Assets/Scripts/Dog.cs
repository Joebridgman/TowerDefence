using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Dog : MonoBehaviour {

    public Waypoint target;
    public float speed;
    public int health;
    public Sprite defaultSprite;
    public Sprite hurtSprite;
    public float hurtTimer;
    private bool nextWaypoint;
    private float waypointTimer;
    private float waypointDelay;

    public Dog() {

    }

    // Start is called before the first frame update
    void Start() {
        var radius = GetComponent<CircleCollider2D>().radius * transform.localScale.x;
        waypointDelay = radius / speed;
    }

    // Update is called once per frame
    void FixedUpdate() {
        hurtTimer += Time.deltaTime;
        waypointTimer += Time.deltaTime;

        if (target != null) {
            transform.position += (transform.position - target.transform.position).normalized * -speed * Time.deltaTime;
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

        if (nextWaypoint) {
            if (waypointTimer > waypointDelay) {
                target = target.nextWaypoint;
                nextWaypoint = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Waypoint") {
            nextWaypoint = true;
            waypointTimer = 0;
        }
    }
}
