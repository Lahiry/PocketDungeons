using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterOrbController : MonoBehaviour
{
    public string colour;

    [SerializeField] private AudioSource orbSound;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.CompareTag("PlayerMovementCollider"))
        {
            if ((colour == "blue") && (collision.transform.parent.name != "Knight(Clone)"))
            {
                orbSound.Play();
            }
            else if ((colour == "green") && (collision.transform.parent.name != "Archer(Clone)"))
            {
                orbSound.Play();
            }
            else if ((colour == "red") && (collision.transform.parent.name != "Mage(Clone)"))
            {
                orbSound.Play();
            }
        }
    }
}
