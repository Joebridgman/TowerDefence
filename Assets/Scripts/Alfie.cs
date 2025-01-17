using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alfie : Cat
{
    public Projectile attackObject;
    public float attackRate;
    private float attackTime = 0;
    private int attackCount = 0;
    private bool isAttacking = false;

    public override void Update() {
        base.Update();
        attackTime += Time.deltaTime;
        if (currentTarget != null && currentAttackCooldown < 0) {
            currentAttackCooldown = attackCooldown;
            isAttacking = true;
            attackTime = 1;
        }
        if (currentAttackCooldown < 1.3) {
            GetComponent<SpriteRenderer>().sprite = defaultSprite;
        }

        if (isAttacking && attackCount < 5 && attackTime >= attackRate) {  
            ThrowMouse();
            attackCount++;
            attackTime = 0;
            if (attackCount >= 5) {
                isAttacking = false;
                attackCount = 0;
            }
        }

        if (currentTarget == null) {
            isAttacking = false;
        }
    }

    void ThrowMouse() {
        var newObject = Instantiate(attackObject, gameObject.transform.position, new Quaternion());
        newObject.GetComponent<Rigidbody2D>().AddForce((gameObject.transform.position -
                                                        currentTarget.transform.position).normalized * -attackObject.speed);
        newObject.GetComponent<Rigidbody2D>().AddTorque(500);
        newObject.currentLifetime = 0;
        GetComponent<SpriteRenderer>().sprite = attackSprite;
    }
}
