using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public GameObject projectile;

    void Start()
    {
        projectile = GameObject.FindWithTag("Arrow");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBodyCollider"))
        {
            EnemyController enemyController = collision.transform.parent.GetComponent<EnemyController>();
            if (collision.transform.parent.name != "Eye")
            {
                enemyController.Die(); 
            }
            Destroy(projectile, 0f);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(projectile, 0f);
        }
    }
}
