using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public Animator animator;
    public GameObject target;

    public float health = 100.0f;

    private bool dead = false;

    public void SustainDamage(float amount)
    {
        if (!dead)
        {
            health = Mathf.Max(health - amount, 0.0f);
            if (health == 0.0f)
            {
                dead = true;
                animator.SetTrigger("Dead");
                Destroy(target);
            }
        }
        
    }
}
