using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject parent;
    public GameObject equipped;

    public Equippable PickUp(GameObject target)
    {
        parent.transform.parent = target.transform;
        parent.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        equipped.SetActive(true);
        return equipped.GetComponent<Equippable>();
    }
}
