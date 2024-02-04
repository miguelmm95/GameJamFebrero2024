using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceWeapon : WeaponBase
{

    [SerializeField] GameObject ricePrefab;

    public override void Attack()
    {
        GameObject throwingRice = Instantiate(ricePrefab);
        throwingRice.transform.position = transform.position;
        throwingRice.GetComponent<ThrowingKnifeProjectile>().SetDirection(vectorOfAttack.x,vectorOfAttack.y);
    }
}
