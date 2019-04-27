using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerControl : MonoBehaviour
{
    public GameObject parent;
    public Tilemap ground;
    public Melee weapon;

    public float moveSpeed = 1.0f;

    public void Update()
    {
        UpdateMovement();
        UpdateAttack();
    }

    private void UpdateMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(horizontal, vertical);
        Vector2 clamped = Vector2.ClampMagnitude(direction, 1);
        Vector2 update = clamped * moveSpeed * Time.deltaTime;
        Vector3 position = parent.transform.position + new Vector3(update.x, update.y, transform.position.z);
        if (ground.HasTile(ground.WorldToCell(position)))
        {
            parent.transform.position = position;
        }
    }

    private void UpdateAttack()
    {
        if (Input.GetButton("Fire1"))
        {
            weapon.Attack();
        }
    }
}
