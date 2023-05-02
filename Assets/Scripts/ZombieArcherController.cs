// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ZombieArcherController : EnemyController
// {
//     public GameObject projectileRightPrefab;
//     public GameObject projectileLeftPrefab;
//     public GameObject projectileFrontPrefab;
//     public GameObject projectileBackPrefab;
//     public Transform projectileSpawnPoint;
//     public float projectileSpeed;
//     public float attackCooldown;

//     private bool canAttack = true;
//     private float attackCooldownTimer;

//     void Update()
//     {
//         base.Update();

//         // check if player is in range then attack in its direction
//         if ()
//         {
//             if (canAttack) 
//             {
//                 isAttacking = true;

//                 GetComponent<Animator>().SetBool("Atk", true);

//                 FireProjectile();

//                 Invoke("FinishAttack", 0.1f);

//                 canAttack = false;
//                 attackCooldownTimer = 0f;
//             }
            
//         }

//         attackCooldownTimer += Time.deltaTime;
//         if (attackCooldownTimer >= attackCooldown)
//         {
//             canAttack = true;
//             attackCooldownTimer = 0f;
//         }
//     }

//     private void FinishAttack()
//     {
//         isAttacking = false;
//         GetComponent<Animator>().SetBool("Atk", false);
//     }

//     void FireProjectile()
//     {
//         if (GetComponent<Animator>().GetBool("FaceRight"))
//         {
//             GameObject projectile = Instantiate(projectileRightPrefab, projectileSpawnPoint.position + new Vector3(0.5f, 0.55f, 0f), Quaternion.identity);
//             Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
//             projectileRigidbody.AddForce(Vector2.right * projectileSpeed);
//             Destroy(projectile, 5f);
//         }
//         if (GetComponent<Animator>().GetBool("FaceLeft"))
//         {
//             GameObject projectile = Instantiate(projectileLeftPrefab, projectileSpawnPoint.position + new Vector3(-0.5f, 0.55f, 0f), Quaternion.identity);
//             Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
//             projectileRigidbody.AddForce(Vector2.left * projectileSpeed);
//             Destroy(projectile, 5f);
//         }
//         if (GetComponent<Animator>().GetBool("FaceFront"))
//         {
//             GameObject projectile = Instantiate(projectileFrontPrefab, projectileSpawnPoint.position + new Vector3(0.1f, 0f, 0f), Quaternion.identity);
//             Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
//             projectileRigidbody.AddForce(Vector2.down * projectileSpeed);
//             Destroy(projectile, 5f);
//         }
//         if (GetComponent<Animator>().GetBool("FaceBack"))
//         {
//             GameObject projectile = Instantiate(projectileBackPrefab, projectileSpawnPoint.position + new Vector3(-0.1f, 0.5f, 0f), Quaternion.identity);
//             Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
//             projectileRigidbody.AddForce(Vector2.up * projectileSpeed);
//             Destroy(projectile, 5f);
//         }
//     }
        
//     }
// }
