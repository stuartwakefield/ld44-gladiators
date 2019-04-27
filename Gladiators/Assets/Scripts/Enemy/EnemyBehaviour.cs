using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject parent;
    public GameObject player;
    public Tilemap ground;
    public Melee weapon;

    public float moveSpeed = 1.0f;

    void Update()
    {
        if (IsAttacking())
        {
            Attack();
        }
        else
        {
            MoveTowards(player);
        }
    }

    private bool IsAttacking()
    {
        return weapon.HasTargets();
    }

    private void MoveTowards(GameObject target)
    {
        Vector3 direction = (target.transform.position - parent.transform.position).normalized;
        Vector3 position = parent.transform.position + direction * moveSpeed * Time.deltaTime;
        if (ground.HasTile(ground.WorldToCell(position)))
        {
            parent.transform.position = position;
        }
    }

    private void Attack()
    {
        weapon.Attack();
    }
}
