using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeapon : WeaponBase
{
    [SerializeField] GameObject leftAttackObject;
    [SerializeField] GameObject rightAttackObject;

    //PlayerMovement playerMovement;
    [SerializeField] Vector2 attackSize = new Vector2(4f, 2f);

    //private void Awake()
    //{
    //    playerMovement = GetComponentInParent<PlayerMovement>();
    //}

    public override void Attack()
    {
        StartCoroutine(AttackProcess());
    }

    IEnumerator AttackProcess()
    {
        if (playerMovement.lastHorizontalDeCoupleVector > 0)
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
        yield return new WaitForSeconds(0.3f);
    }
}
