﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorChecker : MonoBehaviour
{
    public bool[] doorOpen;
    public int test;
    public GameObject[] doors = new GameObject[5];
    public Color[] doorlight = new Color[2];
    public AudioClip doorSoundEffect;
    // Start is called before the first frame update

    // door sound effect : https://www.youtube.com/watch?v=cXqDc6I1NP8
    void Start()
    {
        doorOpen = new bool[doors.Length];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            if (doorOpen[i])
            {
                doors[i].GetComponent<Renderer>().materials[3].color = doorlight[0];
                doors[i].GetComponent<Renderer>().materials[4].color = doorlight[0];
                doors[i].GetComponent<Animator>().SetBool("opening",true);

                StartCoroutine(knockingOnDoor());

                if (test == 0)
                {
                    GetComponent<AudioSource>().PlayOneShot(doorSoundEffect);
                    test++;
                }


            }
            else
            {
                doors[i].GetComponent<Renderer>().materials[3].color = doorlight[1];
                doors[i].GetComponent<Renderer>().materials[4].color = doorlight[1];
                doors[i].GetComponent<Animator>().SetBool("opening", false);
                
            }
        }   
    }

    IEnumerator knockingOnDoor()
    {
    yield return new WaitForSeconds(doorSoundEffect.length);
    test = 0;

    }
}
