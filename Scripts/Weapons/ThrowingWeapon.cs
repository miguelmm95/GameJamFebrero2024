using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingWeapon : WeaponBase
{
    [SerializeField] GameObject knifePrefab;


    public override void Attack()
    {
        UpdateVectorOfAttack();
        GameObject throwingKnife = Instantiate(knifePrefab);
        throwingKnife.transform.position = transform.position;
        throwingKnife.GetComponent<ThrowingKnifeProjectile>().SetDirection(vectorOfAttack.x,vectorOfAttack.y);
    }
}
