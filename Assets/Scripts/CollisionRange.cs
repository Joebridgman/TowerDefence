using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionRange : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Bound") {
            GetComponentInParent<Cat>().blockingBounds.Add(collision.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Bound") {
            GetComponentInParent<Cat>().blockingBounds.Remove(collision.gameObject);
        }
    }
}
