using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerControl : MonoBehaviour
{
    public GameObject parent;
    public Animator animator;
    public Tilemap ground;
    public Melee weapon;
    public SpriteRenderer sprite;
    public AudioSource soundEffect;

    public float moveSpeed = 1.0f;
    private bool isFireDown = false;

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
        if (direction.magnitude > 0.1f)
        {
            animator.SetBool("Walking", true);
            if (!soundEffect.isPlaying) soundEffect.Play();
        }
        else
        {
            animator.SetBool("Walking", false);
            if (soundEffect.isPlaying) soundEffect.Stop();
        }
        if (direction.magnitude > 0.1f && sprite.flipX == direction.x > 0.0f)
        {
            sprite.flipX = !sprite.flipX;
        }
        Vector2 clamped = Vector2.ClampMagnitude(direction, 1);
        Vector2 update = clamped * moveSpeed * Time.deltaTime;
        Vector3 position = parent.transform.position + new Vector3(update.x, update.y, parent.transform.position.z);
        if (ground.HasTile(ground.WorldToCell(position)))
        {
            parent.transform.position = position;
        }
    }

    private void UpdateAttack()
    {
        if (!isFireDown && Input.GetButtonDown("Fire1"))
        {
            weapon.Attack();
            isFireDown = true;
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            isFireDown = false;
        }
    }

    public void EquipWeapon(Melee weapon)
    {
        this.weapon.gameObject.SetActive(false);
        this.weapon = weapon;
        this.weapon.Arm(parent, animator);
    }
}
