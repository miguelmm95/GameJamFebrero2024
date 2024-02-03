using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeapon : WeaponBase
{
    [SerializeField] GameObject leftAttackObject;
    [SerializeField] GameObject rightAttackObject;

    PlayerMovement playerMovement;
    [SerializeField] Vector2 attackSize = new Vector2(4f, 2f);

    private void Awake()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for(int i = 0; i < colliders.Length; i++)
        {
            IDamageable e = colliders[i].GetComponent<IDamageable>();

            if(e != null)
            {
                e.TakeDamage(weaponStats.damage);
            }
        }
    }

    public override void Attack()
    {
        if (playerMovement.lastHorizontalVector > 0)
        {
            rightAttackObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightAttackObject.transform.position, attackSize, 0f);
            ApplyDamage(colliders);
        }
        else
        {
            leftAttackObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftAttackObject.transform.position, attackSize, 0f);
            ApplyDamage(colliders);
        }
    }
}
