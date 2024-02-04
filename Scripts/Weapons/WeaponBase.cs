using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DirectionOfAttack
{
    None,
    Forward,
    LeftRight,
    UpDown
}

public abstract class WeaponBase : MonoBehaviour
{
    public WeaponData weaponData;
    public WeaponStats weaponStats;
    public PlayerMovement playerMovement;

    public float timeToAttack;
    public float usageTime;
    float timer;

    public Vector2 vectorOfAttack;
    [SerializeField] DirectionOfAttack attackDirection;

    private void Awake()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

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

    public int GetDamage()
    {
        int damage = (int)(weaponData.stats.damage);
        return damage;
    }

    public virtual void SetData(WeaponData wd)
    {
        weaponData = wd;
        timeToAttack = weaponData.stats.timeToAttack;
        usageTime = weaponData.stats.usageTime;

        weaponStats = new WeaponStats(wd.stats.damage, wd.stats.timeToAttack, wd.stats.usageTime);
    }

    public abstract void Attack();

    public void ApplyDamage(Collider2D[] colliders)
    {
        int damage = GetDamage();
        for (int i = 0; i < colliders.Length; i++)
        {
            IDamageable e = colliders[i].GetComponent<IDamageable>();

            if (e != null)
            {
                e.TakeDamage(weaponStats.damage);
            }
        }
    }

    public void UpdateVectorOfAttack()
    {
        if(attackDirection == DirectionOfAttack.None)
        {
            vectorOfAttack = Vector2.zero;
            return;
        }

        switch (attackDirection)
        {
            case DirectionOfAttack.Forward:
                vectorOfAttack.x = playerMovement.lastHorizontalCoupleVector;
                vectorOfAttack.y = playerMovement.lastVerticalCoupledVector;
                break;
            case DirectionOfAttack.LeftRight:
                vectorOfAttack.x = playerMovement.lastHorizontalDeCoupleVector;
                vectorOfAttack.y = 0f;
                break;
            case DirectionOfAttack.UpDown:
                vectorOfAttack.x = 0f;
                vectorOfAttack.y = playerMovement.lastVerticalDeCoupledVector;
                break;
        }
        vectorOfAttack = vectorOfAttack.normalized;
    }
}
