using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public Animator animator;
    public GameObject target;

    public float health = 100.0f;

    private bool dead = false;
    private float currentHealth;

    public void Start()
    {
        currentHealth = health;
    }

    public float HealthFraction()
    {
        return currentHealth / health;
    }

    public void SustainDamage(float amount)
    {
        if (!dead)
        {
            currentHealth = Mathf.Max(currentHealth - amount, 0.0f);
            if (currentHealth == 0.0f)
            {
                dead = true;
                animator.SetTrigger("Dead");
                Destroy(target);
            }
        }
    }
}
