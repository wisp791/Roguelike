using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;
using UnityEngine;

[System.Serializable]

public class WeaponDataEvent : UnityEvent<WeaponData> { }

public class WeaponHandler : MonoBehaviour
{
    public Weapon[] weapons = new Weapon[6];
    public WeaponDataEvent AddWeaponEvent;

    void Start()
    {
        weapons = gameObject.GetComponentsInChildren<Weapon>();
        AddWeaponEvent.AddListener(AddWeapon);
    }

    void Update()
    {

    }

    public void AddWeapon(WeaponData weaponData)
    {
        Debug.Log("Adding weapon: " + weaponData.weaponName);
        GameObject empty = new GameObject(weaponData.weaponName);
        empty.transform.parent = transform;
        Weapon weapon = empty.AddComponent<Weapon>();
        weapon.weaponData = weaponData;
        weapons.Append<Weapon>(weapon);

        Debug.Log(weapons.Length);
    }
}