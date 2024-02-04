using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : WeaponBase
{

    [SerializeField] GameObject fireParticles;

    public override void Attack()
    {
        GameObject fire = Instantiate(fireParticles);
        fire.transform.position = transform.position;
    }
}
