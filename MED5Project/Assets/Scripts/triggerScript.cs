using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerScript : MonoBehaviour
{
    public doorChecker openingDoor;
    public TrackingFromHeadset booleanTrigger;
    public int doorId;
    public string[] interactiveObjectNames;
    public AudioSource audioForThis,audioForNext;


    private void OnTriggerEnter(Collider other)
    {
        

        if (audioForNext != null)
        {
            audioForNext.mute = false;
        }

        if (other.CompareTag("rightHand") && gameObject.name == interactiveObjectNames[0] && !openingDoor.doorOpen[doorId])
        {
            openingDoor.doorOpen[doorId] = true;
            audioForThis.mute = true;
            audioForNext.mute = false;
            openingDoor.doors[0].GetComponent<AudioSource>().Play();
            openingDoor.doors[2].GetComponent<AudioSource>().Play();
            booleanTrigger.triggersForIntervalTime[0] = true;
            Debug.Log(other.tag.ToString());
        }
        if (other.CompareTag("rightHand") && gameObject.name == interactiveObjectNames[1] && !openingDoor.doorOpen[doorId])
        {
            openingDoor.doorOpen[doorId] = true;
            audioForThis.mute = true;
            audioForNext.mute = false;
            openingDoor.doors[1].GetComponent<AudioSource>().Play();
            booleanTrigger.triggersForIntervalTime[1] = true;
            Debug.Log(other.tag.ToString());

        }
        if (other.CompareTag("head") && gameObject.name == interactiveObjectNames[2] && !openingDoor.doorOpen[doorId] || other.CompareTag("head") && gameObject.name == interactiveObjectNames[3] && !openingDoor.doorOpen[doorId])
        {
            openingDoor.doorOpen[doorId] = true;
            audioForThis.mute = true;
            audioForNext.mute = false;
            openingDoor.doors[3].GetComponent<AudioSource>().Play();
            booleanTrigger.triggersForIntervalTime[2] = true;
            booleanTrigger.triggersForIntervalTime[3] = true;
            GameObject.Find("note(Office)").SetActive(true);
            Debug.Log(other.tag.ToString());
        }
        if (other.CompareTag("rightHand") && gameObject.name == interactiveObjectNames[4] && !openingDoor.doorOpen[doorId])
        {
            openingDoor.doorOpen[doorId] = true;
            audioForThis.mute = true;
            audioForNext.mute = false;
            booleanTrigger.triggersForIntervalTime[4] = true;
            Debug.Log(other.tag.ToString());
        }
    }
}
