using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData weaponData;
    public Shoot S;
    // Start is called before the first frame update
    void Start()
    {
        S = gameObject.GetComponent<Shoot>();
        if (S == null)
        {
            gameObject.AddComponent<Shoot>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
