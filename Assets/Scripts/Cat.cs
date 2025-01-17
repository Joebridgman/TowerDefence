using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Cat : MonoBehaviour
{

    public int range;
    public List<Dog> targets;
    public float attackCooldown;
    public Sprite defaultSprite;
    public Sprite attackSprite;
    public int rotation;
    protected Dog currentTarget;
    protected float currentAttackCooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<CircleCollider2D>().radius = range;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        currentAttackCooldown -= Time.deltaTime;

        if (targets.Count > 0) {
            //attack modes
            currentTarget = targets[0];
            Vector3 targ = targets[0].transform.position;
            targ.z = 0f;

            Vector3 objectPos = transform.position;
            targ.x = targ.x - objectPos.x;
            targ.y = targ.y - objectPos.y;

            float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotation));     
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Dog") {
            targets.Add(collision.gameObject.GetComponent<Dog>());
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Dog") {
            targets.Remove(collision.gameObject.GetComponent<Dog>());
            currentTarget = null;
        }
    }

}
