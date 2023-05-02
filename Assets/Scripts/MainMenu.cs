using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject knightPrefab;
    public GameObject knightPortraitPrefab;

    public void PlayGame()
    {
        SceneManager.LoadScene("Tutorial1");
        SpawnController.SetLastCharacter(knightPrefab);
        SpawnController.SetLastCharacterPortrait(knightPortraitPrefab);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
