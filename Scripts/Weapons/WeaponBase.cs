using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public WeaponData weaponData;

    public WeaponStats weaponStats;

    public float timeToAttack;
    public float usageTime;
    float timer;

    public void Update()
    {
        timer -= Time.deltaTime;
        usageTime -= Time.deltaTime;

        if(timer < 0)
        {
            Attack();
            timer = timeToAttack;
        }

        if(usageTime < 0)
        {
            Destroy(gameObject);
        }
    }

    public virtual void SetData(WeaponData wd)
    {
        weaponData = wd;
        timeToAttack = weaponData.stats.timeToAttack;
        usageTime = weaponData.stats.usageTime;

        weaponStats = new WeaponStats(wd.stats.damage, wd.stats.timeToAttack, wd.stats.usageTime);
    }

    public abstract void Attack();
}
