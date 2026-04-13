using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUI : MonoBehaviour
{
    public Equipment equipment;
    public Image weaponIcon;

    private void Start()
    {
        equipment.onEquipmentChanged += Refresh;
        Refresh();
    }

    void Refresh()
    {
        if (equipment.equipedWeapon != null)
        {
            weaponIcon.sprite = equipment.equipedWeapon.icon;
            weaponIcon.enabled = true;
        }
        else
        {
            weaponIcon.enabled = false;
        }
    }
}
