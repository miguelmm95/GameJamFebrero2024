using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingWeapon : WeaponBase
{
    PlayerMovement playerMovement;

    [SerializeField] GameObject knifePrefab;

    private void Awake()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    public override void Attack()
    {
        GameObject throwingKnife = Instantiate(knifePrefab);
        throwingKnife.transform.position = transform.position;
        throwingKnife.GetComponent<ThrowingKnifeProjectile>().SetDirection(playerMovement.lastHorizontalVector, 0f);
    }
}
