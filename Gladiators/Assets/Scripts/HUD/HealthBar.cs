using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject bar;
    public Damage damage;

    void Update()
    {
        bar.transform.localScale = new Vector3(damage.HealthFraction(), 1.0f);
    }
}
