using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpOptionWeapon : LevelUpOptionsBase
{
    public WeaponData weaponData;
    public WeaponDataEvent AddWeaponEvent;

    public LevelUpOptionWeapon(int weight, WeaponData weaponData)
    {
        this.weight = weight;
        this.weaponData = weaponData;
        this.AddWeaponEvent = Object.FindFirstObjectByType<WeaponHandler>().AddWeaponEvent;
    }

    public override void Execute()
    {
        AddWeaponEvent.Invoke(weaponData);
    }

    public override string GetDescription()
    {
        return weaponData.weaponName;
    }
}
