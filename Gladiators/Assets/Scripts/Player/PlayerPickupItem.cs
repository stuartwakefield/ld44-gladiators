using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupItem : MonoBehaviour
{
    public GameObject parent;
    public PlayerControl control;
    public GameObject defaultWeapon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();
        if (item)
        {
            item.gameObject.SetActive(false);
            defaultWeapon.SetActive(false);
            item.parent.transform.parent = parent.transform;
            item.parent.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            item.equipped.SetActive(true);
            control.weapon = item.equipped.GetComponent<Melee>();
        }
    }
}
