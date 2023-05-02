using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public string nextDungeon;

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.CompareTag("PlayerMovementCollider"))
        {
            SceneManager.LoadScene(nextDungeon);
            DeathMenu.currentDungeon = nextDungeon;
        }
    }
}
