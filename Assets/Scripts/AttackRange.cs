using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AttackRange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CircleCollider2D>().radius = GetComponentInParent<Cat>().range;   
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Dog") {
            GetComponentInParent<Cat>().targets.Add(collision.gameObject.GetComponent<Dog>());
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Dog") {
            GetComponentInParent<Cat>().targets.Remove(collision.gameObject.GetComponent<Dog>());
            GetComponentInParent<Cat>().currentTarget = null;
        }
    }
}
