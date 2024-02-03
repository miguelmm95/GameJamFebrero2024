using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class WeaponStats
{
    public int damage;
    public float timeToAttack;
    public float usageTime;

    public WeaponStats(int damage, float timeToAttack, float usageTime)
    {
        this.damage = damage;
        this.timeToAttack = timeToAttack;
        this.usageTime = usageTime;
    }
}

[CreateAssetMenu]

public class WeaponData : ScriptableObject
{
    public string Name;
    public WeaponStats stats;
    public GameObject weaponBasePrefab;
}
