using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorChecker : MonoBehaviour
{
    public bool[] doorOpen;
    public GameObject[] doors = new GameObject[5];
    public GameObject[] teleportplanes;
    public Color[] doorlight = new Color[2];
    public AudioClip doorSoundEffect;
    // Start is called before the first frame update

    // door sound effect : https://www.youtube.com/watch?v=cXqDc6I1NP8
    void Start()
    {
        doorOpen = new bool[doors.Length];
        teleportplanes[7].SetActive(true);
        teleportplanes[8].SetActive(true);
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
            }
            else
            {
                doors[i].GetComponent<Renderer>().materials[3].color = doorlight[1];
                doors[i].GetComponent<Renderer>().materials[4].color = doorlight[1];
                doors[i].GetComponent<Animator>().SetBool("opening", false);
                
            }
        }

        if (doorOpen[0])
        {
            for (int i = 0; i < 3; i++)
            {
                teleportplanes[i].SetActive(true);
            }
        }
        if (doorOpen[1])
        {
            for (int i = 3; i < 5; i++)
            {
                teleportplanes[i].SetActive(true);
            }
        }
        if (doorOpen[2])
        {
            for (int i = 5; i < 7; i++)
            {
                teleportplanes[i].SetActive(true);
            }
        }
    }

}
