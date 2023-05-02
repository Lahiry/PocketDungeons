using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public static string currentDungeon;

    private GameObject player;

    public void Respawn()
    {
        if (currentDungeon == null)
        {
            SceneManager.LoadScene("Tutorial1");
        }
        else
        { 
            SceneManager.LoadScene(currentDungeon);
            SpawnController.SetLastCharacter(SpawnController.initialCharacter);
            SpawnController.SetLastCharacterPortrait(SpawnController.initialCharacterPortrait);
        }
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
