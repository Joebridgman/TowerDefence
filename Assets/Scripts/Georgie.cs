using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Georgie : Cat
{
    public Projectile woolObject;

    public override void Update() {
        base.Update();
        if (currentTarget != null && currentAttackCooldown < 0) {
            currentAttackCooldown = attackCooldown;
            ThrowWool();
        }
        if (currentAttackCooldown < 0.5) {
            GetComponent<SpriteRenderer>().sprite = defaultSprite;
        }
    }

    void ThrowWool() {
        var newObject = Instantiate(woolObject, gameObject.transform.position, new Quaternion());
        newObject.GetComponent<Rigidbody2D>().AddForce((gameObject.transform.position -
                                                        currentTarget.transform.position).normalized * -woolObject.speed);
        newObject.GetComponent<Rigidbody2D>().AddTorque(200);
        newObject.currentLifetime = 0;
        GetComponent<SpriteRenderer>().sprite = attackSprite;
    }
}
