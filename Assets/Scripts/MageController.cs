using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageController : PlayerController
{
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public float projectileSpeed;
    public float attackCooldown;

    private bool canAttack = true;
    private float attackCooldownTimer;

    [SerializeField] private AudioSource attackSound;

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

                FireProjectile();

                Invoke("FinishAttack", 0.1f);

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

    private void FinishAttack()
    {
        isAttacking = false;
        GetComponent<Animator>().SetBool("Atk", false);
    }

    void FireProjectile()
    {
        if (GetComponent<Animator>().GetFloat("LastHorizontal") == 1)
        {
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position + new Vector3(0.5f, 0.55f, 0f), Quaternion.identity);
            Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
            projectileRigidbody.AddForce(Vector2.right * projectileSpeed);
            Destroy(projectile, 5f);
        }
        if (GetComponent<Animator>().GetFloat("LastHorizontal") == -1)
        {
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position + new Vector3(-0.5f, 0.55f, 0f), Quaternion.identity);
            Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
            projectileRigidbody.AddForce(Vector2.left * projectileSpeed);
            Destroy(projectile, 5f);
        }
        if (GetComponent<Animator>().GetFloat("LastVertical") == -1)
        {
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position + new Vector3(0.1f, 0f, 0f), Quaternion.identity);
            Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
            projectileRigidbody.AddForce(Vector2.down * projectileSpeed);
            Destroy(projectile, 5f);
        }
        if (GetComponent<Animator>().GetFloat("LastVertical") == 1)
        {
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position + new Vector3(-0.1f, 0.5f, 0f), Quaternion.identity);
            Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
            projectileRigidbody.AddForce(Vector2.up * projectileSpeed);
            Destroy(projectile, 5f);
        }
    }
}
