using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Milo : Cat
{
    public Projectile attackObject;
    public float attackRate;
    private float attackTime = 0;
    private int attackCount = 0;
    private bool isAttacking = false;

    public override void Update() {
        base.Update();
        if (currentTarget != null && currentAttackCooldown < 0) {
            currentAttackCooldown = attackCooldown;
            ThrowWool();
        }

        if (gameObject.transform.rotation.z > 0.7 || gameObject.transform.rotation.z < -0.7) {
            GetComponent<SpriteRenderer>().flipY = true;
        }
        else {
            GetComponent<SpriteRenderer>().flipY = false;
        }
    }

    void ThrowWool() {
        var newObject = Instantiate(attackObject, gameObject.transform.position, new Quaternion());
        newObject.GetComponent<Rigidbody2D>().AddForce((gameObject.transform.position -
                                                        currentTarget.transform.position).normalized * -attackObject.speed);
        
        newObject.currentLifetime = 0;
    }
}
