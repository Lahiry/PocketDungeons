using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : PlayerController
{
    public Collider2D weaponColliderRight;
    public Collider2D weaponColliderLeft;
    public Collider2D weaponColliderFront;
    public Collider2D weaponColliderBack;

    public float attackCooldown;

    private bool canAttack = true;
    private float attackCooldownTimer;

    [SerializeField] private AudioSource attackSound;

    void Start()
    {
        base.Start();

        weaponColliderLeft.enabled = false;
        weaponColliderRight.enabled = false;
        weaponColliderFront.enabled = false;
        weaponColliderBack.enabled = false;
    }

    void Update()
    {   
        base.Update();

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (canAttack) 
            {
                isAttacking = true;

                idleTime = 0f;

                attackSound.Play();

                GetComponent<Animator>().SetBool("Atk", true);

                Invoke("ActivateWeaponCollider", 0.25f);

                Invoke("DeactivateWeaponCollider", 0.35f);

                canAttack = false;
                attackCooldownTimer = 0f;
            }
            
        }

        attackCooldownTimer += Time.deltaTime;
        if (attackCooldownTimer >= attackCooldown)
        {
            canAttack = true;
            attackCooldownTimer = 0f;
        }
        
    }

    private void ActivateWeaponCollider()
    {
        if (GetComponent<Animator>().GetFloat("LastHorizontal") == 1)
        {
            weaponColliderRight.enabled = true;
        }
        else if (GetComponent<Animator>().GetFloat("LastHorizontal") == -1)
        {
            weaponColliderLeft.enabled = true;
        }
        else if (GetComponent<Animator>().GetFloat("LastVertical") == -1)
        {
            weaponColliderFront.enabled = true;
        }
        else if (GetComponent<Animator>().GetFloat("LastVertical") == 1)
        {
            weaponColliderBack.enabled = true;
        }
    }

    private void DeactivateWeaponCollider()
    {
        isAttacking = false;

        GetComponent<Animator>().SetBool("Atk", false);

        weaponColliderRight.enabled = false;
        weaponColliderLeft.enabled = false;
        weaponColliderFront.enabled = false;
        weaponColliderBack.enabled = false;
    }
}
