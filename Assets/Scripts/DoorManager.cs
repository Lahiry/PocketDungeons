using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{   
    public GameObject door;
    public GameObject[] monsters;

    private bool canOpenDoor;

    void Update()
    {
        foreach (GameObject monster in monsters)
        {
            if (!monster)
            {
                canOpenDoor = true;
            }
            else {
                canOpenDoor = false;
            }

        }

        if (canOpenDoor)
        {
            door.SetActive(false);
        }
    }
}
