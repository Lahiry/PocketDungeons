using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class TreasureController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.CompareTag("PlayerFeetCollider"))
        {
            SceneManager.LoadScene("WinMenu");
        }
    }
}
