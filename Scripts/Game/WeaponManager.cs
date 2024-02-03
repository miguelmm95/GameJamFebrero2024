using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;

    [SerializeField] Transform weaponObjectContainer;
    [SerializeField] WeaponData startingWeapon;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if(startingWeapon != null)
        {
            AddWeapon(startingWeapon);
        }
    }

    public void AddWeapon(WeaponData weaponData)
    {
        GameObject weaponGameObject = Instantiate(weaponData.weaponBasePrefab, weaponObjectContainer);

        weaponGameObject.GetComponent<WeaponBase>().SetData(weaponData);
    }
}
