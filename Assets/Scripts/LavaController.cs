using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.CompareTag("PlayerFeetCollider"))
        {
            PlayerController playerController = collision.transform.parent.GetComponent<PlayerController>();
            playerController.Die(); 
        }
    }
}
