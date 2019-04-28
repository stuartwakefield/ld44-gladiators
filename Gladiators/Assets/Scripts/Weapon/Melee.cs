using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public GameObject parent;
    public Animator animator;
    public AudioSource soundEffect;
    public int layerIndex;

    public float attackRate = 1.0f;
    public float attackDamage = 10.0f;

    private List<GameObject> attackTargets = new List<GameObject>();
    private double lastAttack = 0.0;

    public void Start()
    {
        animator.SetLayerWeight(layerIndex, 1);
    }

    public void Attack()
    {
        if (lastAttack < Time.time - attackRate)
        {
            animator.SetTrigger("Attack");
            soundEffect.Play();
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
            damage.SustainDamage(attackDamage, (attackTarget.transform.position - parent.transform.position).normalized);
        }
    }

    public void Arm(GameObject parent, Animator animator)
    {
        this.parent = parent;
        this.animator = animator;
        animator.SetLayerWeight(layerIndex, 1);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Damage damage = collision.gameObject.GetComponent<Damage>();
        if (damage && damage.IsFoe(parent))
        {
            attackTargets.Add(collision.gameObject);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Damage damage = collision.gameObject.GetComponent<Damage>();
        if (damage && damage.IsFoe(parent))
        {
            attackTargets.Remove(collision.gameObject);
        }
    }

    public void Update()
    {
        List<GameObject> deadTargets = new List<GameObject>();
        foreach (GameObject attackTarget in attackTargets)
        {
            Damage damage = attackTarget.GetComponent<Damage>();
            if (damage.IsDead())
            {
                deadTargets.Add(attackTarget);
            }
        }
        foreach (GameObject deadTarget in deadTargets)
        {
            attackTargets.Remove(deadTarget);
        }
    }
}
