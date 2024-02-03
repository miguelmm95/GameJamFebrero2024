using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour, IPickupObject
{
    [SerializeField] WeaponData weaponData;

    public void OnPickUp(Player player)
    {
        WeaponManager.instance.AddWeapon(weaponData);
        Destroy(gameObject);
    }
}
