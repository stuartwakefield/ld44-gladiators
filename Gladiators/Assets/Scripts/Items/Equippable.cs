using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equippable : MonoBehaviour
{
    public Melee weapon;

    public void Equip(PlayerControl control)
    {
        control.EquipWeapon(weapon);
    }
}
