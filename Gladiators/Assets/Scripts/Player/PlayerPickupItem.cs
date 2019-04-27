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

            // Specific to weapon
            defaultWeapon.SetActive(false);
            item.parent.transform.parent = parent.transform;

            // Local position will be specific to each weapon
            item.parent.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            item.equipped.SetActive(true);

            // Specific to melee
            item.equipped.GetComponent<Melee>().parent = parent;
            control.weapon = item.equipped.GetComponent<Melee>();
        }
    }
}
