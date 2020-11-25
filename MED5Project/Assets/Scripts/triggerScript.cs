using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerScript : MonoBehaviour
{
    public doorChecker openingDoor;
    public int doorId;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            openingDoor.doorOpen[doorId] = true;
        }
    }
}
