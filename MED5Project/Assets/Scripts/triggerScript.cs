using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerScript : MonoBehaviour
{
    public doorChecker openingDoor;
    public int doorId;
    public AudioSource audioForThis,audioForNext;


    private void OnTriggerEnter(Collider other)
    {
        /*if (other.tag == "Player")
         {
             openingDoor.doorOpen[doorId] = true;
             audioForThis.mute = true;
             if (audioForNext != null)
             {
                 audioForNext.mute = false;
             }
             if (doorId ==0 && other.tag == "rightHand")
             {
                 openingDoor.doors[0].GetComponent<AudioSource>().Play();
             }
             if (doorId == 1 && other.tag == "rightHand")
             {
                 openingDoor.doors[1].GetComponent<AudioSource>().Play();
             }

             if (doorId == 2 && other.tag == "head")
             {
                 openingDoor.doors[3].GetComponent<AudioSource>().Play();
             }

         }*/

        if (other.CompareTag("rightHand"))
        {
            Debug.Log("dis is the right hand meme");
        }
    }
}
