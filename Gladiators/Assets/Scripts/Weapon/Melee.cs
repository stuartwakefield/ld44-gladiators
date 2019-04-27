using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public float attackRate = 1.0f;
    public float attackDamage = 10.0f;

    private List<GameObject> attackTargets = new List<GameObject>();
    private double lastAttack = 0.0;

    public void Attack()
    {
        if (lastAttack < Time.time - attackRate)
        {
            AttackAllWithinRange();
            lastAttack = Time.time;
        }
    }

    public bool HasTargets()
    {
        return attackTargets.Count > 0;
    }

    private void AttackAllWithinRange()
    {
        foreach (GameObject attackTarget in attackTargets)
        {
            Damage damage = attackTarget.GetComponent<Damage>();
            damage.SustainDamage(attackDamage);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Damage damage = collision.gameObject.GetComponent<Damage>();
        if (damage)
        {
            attackTargets.Add(collision.gameObject);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Damage damage = collision.gameObject.GetComponent<Damage>();
        if (damage)
        {
            attackTargets.Remove(collision.gameObject);
        }
    }
}
