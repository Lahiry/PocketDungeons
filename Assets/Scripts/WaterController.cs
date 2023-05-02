using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.CompareTag("PlayerFeetCollider"))
        {
            PlayerController playerController = collision.transform.parent.GetComponent<PlayerController>();

            if (!playerController.slowed)
            {
                playerController.moveSpeed = (playerController.moveSpeed - (playerController.moveSpeed * 0.5f)); 
                playerController.slowed = true;
            }   
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {   
        if (collision.gameObject.CompareTag("PlayerFeetCollider"))
        {
            PlayerController playerController = collision.transform.parent.GetComponent<PlayerController>();

            if (playerController.slowed)
            {
                playerController.moveSpeed = (playerController.moveSpeed * 2f); 
                playerController.slowed = false;
            }
        }
    }
}
