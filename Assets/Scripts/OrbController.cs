using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{
    public GameObject projectile;

    void Start()
    {
        projectile = GameObject.FindWithTag("Orb");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBodyCollider"))
        {
            EnemyController enemyController = collision.transform.parent.GetComponent<EnemyController>();
            enemyController.Die(); 
            Destroy(projectile, 0f);
        }
    }
}
