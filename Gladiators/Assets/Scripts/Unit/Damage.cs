using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damage : MonoBehaviour
{
    public UnityEvent onDead;

    public Animator animator;
    public GameObject target;
    public Rigidbody2D body;
    public AudioSource soundDeath;
    public AudioSource soundHurt;

    public float health = 100.0f;
    public int team = 0;

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

    public void SustainDamage(float amount, Vector2 direction)
    {
        if (!dead)
        {
            currentHealth = Mathf.Max(currentHealth - amount, 0.0f);
            body.AddForce(amount * direction);
            if (currentHealth == 0.0f)
            {
                dead = true;
                animator.SetBool("Dead", true);
                soundDeath.Play();
                Destroy(target);
                if (onDead != null)
                {
                    onDead.Invoke();
                }
            }
            else
            {
                soundHurt.Play();
            }
        }
    }

    public bool IsFoe(GameObject target)
    {
        Damage damage = target.GetComponent<Damage>();
        return damage && !damage.IsAllyWithTeam(team);
    }

    public bool IsAllyWithTeam(int team)
    {
        return this.team == team;
    }

    public bool IsDead()
    {
        return dead;
    }
}
