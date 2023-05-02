using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject knightPrefab;
    public GameObject knightPortraitPrefab;

    public static GameObject lastCharacter;
    public static GameObject lastCharacterPortrait;

    public static GameObject initialCharacter;
    public static GameObject initialCharacterPortrait;

    [SerializeField] private AudioSource teleportSound;


    private void Awake()
    {
        Canvas canvas = FindObjectOfType<Canvas>();

        if (lastCharacter == null)
        {
            Instantiate(knightPrefab, transform.position, Quaternion.identity);
            GameObject portrait = Instantiate(knightPortraitPrefab, canvas.transform);

            initialCharacter = knightPrefab;
            initialCharacterPortrait = knightPortraitPrefab;
        }
        else
        {
            Instantiate(lastCharacter, transform.position, Quaternion.identity);
            GameObject portrait = Instantiate(lastCharacterPortrait, canvas.transform);

            initialCharacter = lastCharacter;
            initialCharacterPortrait = lastCharacterPortrait;
        }

        teleportSound.Play();
    }

    public static void SetLastCharacter(GameObject character)
    {
        lastCharacter = character;
    }

    public static void SetLastCharacterPortrait(GameObject characterPortrait)
    {
        lastCharacterPortrait = characterPortrait;
    }
}