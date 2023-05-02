using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public GameObject magePortrait;
    public GameObject archerPortrait;
    public GameObject knightPortrait;


    public void SetCharacterPortrait(GameObject portrait)
    {
        GameObject currentPortrait = GameObject.FindGameObjectWithTag("Portrait");
        Vector3 portraitPosition = currentPortrait.transform.position;
        Quaternion portraitRotation = currentPortrait.transform.rotation;
        Destroy(currentPortrait);
        GameObject newPortrait = Instantiate(portrait, portraitPosition, portraitRotation, currentPortrait.transform.parent);
    }

}
