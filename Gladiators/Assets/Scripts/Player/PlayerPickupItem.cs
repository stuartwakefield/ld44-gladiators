using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupItem : MonoBehaviour
{
    public GameObject parent;
    public Animator animator;
    public PlayerControl control;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();
        if (item)
        {
            item.gameObject.SetActive(false);
            Equippable equippable = item.PickUp(parent);
            equippable.Equip(control);
        }
    }
}
