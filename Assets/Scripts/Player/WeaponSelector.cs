using System;
using System.Collections.Generic;
using UnityEngine;

public enum Weapons
{
    Null = -1,
    BasicGun,

}

public class WeaponSelector : MonoBehaviour
{
    [SerializeField] private List<IWeapon> weapons = null;

    private WeaponController shooter = null;
    private Weapons weapon;

    private void Awake()
    {
        shooter = this.GetComponent<WeaponController>();
        weapon = Weapons.BasicGun;
    }

    private void Update()
    {
        if (!Input.GetKeyUp(KeyCode.Q)) return;
        weapon = (Weapons)((int) ++weapon % weapons.Count);
        shooter.SetWeapon(weapons[(int) weapon]);
    }
}