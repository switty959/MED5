using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorChecker : MonoBehaviour
{
    public int testprep; // 0 = baseline , 1 = light only, 2 = sound only, 3 = sound + light
    public string testObjectName;
    public bool[] doorOpen;

    public GameObject[] doors = new GameObject[4];
    public GameObject[] teleportplanes;
    public Color[] doorlight = new Color[2];
    public GameObject[] lightForObject = new GameObject[4];
    public AudioSource[] audioForObject = new AudioSource[4];

    public AudioClip doorSoundEffect;
    // Start is called before the first frame update

    // door sound effect : https://www.youtube.com/watch?v=cXqDc6I1NP8

    private void Awake()
    {
        testprep = GameObject.Find(testObjectName).GetComponent<twoXtwoTest>().test;
    }
    void Start()
    {
        doorOpen = new bool[doors.Length];
        teleportplanes[4].SetActive(true);

        for (int i = 0; i < lightForObject.Length; i++)
        {
            lightForObject[i].SetActive(false);
        }

        for (int i = 0; i < audioForObject.Length; i++)
        {
            audioForObject[i].enabled = false;
        }
        lightForObject[0].SetActive(true);
        audioForObject[4].enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        teleportplanes[4].SetActive(true);
        teleportplanes[4].transform.GetChild(0).gameObject.SetActive(true);
        teleportplanes[4].transform.GetChild(1).gameObject.SetActive(true);



        if (testprep == 0)
        {
            for (int i = 0; i < lightForObject.Length; i++)
            {
                lightForObject[i].SetActive(false);
                audioForObject[i].enabled = false;
            }
        }
        if (testprep == 1)
        {
            for (int i = 0; i < lightForObject.Length; i++)
            {
                audioForObject[i].enabled = false;
            }
        }
        if (testprep == 2)
        {
            for (int i = 0; i < lightForObject.Length; i++)
            {
                lightForObject[i].SetActive(false);
            }
        }
        if (testprep == 3)
        {
            for (int i = 0; i < lightForObject.Length; i++)
            {
                lightForObject[i].SetActive(true);
                audioForObject[i].enabled = true;
            }
        }


        if (doorOpen[0])
        {
            teleportplanes[0].SetActive(true);
            teleportplanes[2].SetActive(true);

            //opens backLeftDoor
            doors[0].GetComponent<Renderer>().materials[3].color = doorlight[0];
            doors[0].GetComponent<Renderer>().materials[4].color = doorlight[0];
            doors[0].GetComponent<Animator>().SetBool("opening", true);

            //opens frontRightDoor
            doors[2].GetComponent<Renderer>().materials[3].color = doorlight[0];
            doors[2].GetComponent<Renderer>().materials[4].color = doorlight[0];
            doors[2].GetComponent<Animator>().SetBool("opening", true);

            //disable sound and spotlight for laptop
            audioForObject[4].enabled = false;
            lightForObject[0].SetActive(false);

            //enable sound and light for dresser
            audioForObject[3].enabled = true;
            lightForObject[1].SetActive(true);




        }
        if (doorOpen[1])
        {
            teleportplanes[3].SetActive(true);

            doors[1].GetComponent<Renderer>().materials[3].color = doorlight[0];
            doors[1].GetComponent<Renderer>().materials[4].color = doorlight[0];
            doors[1].GetComponent<Animator>().SetBool("opening", true);


            //disable sound and light for dresser
            audioForObject[3].enabled = false;
            lightForObject[1].SetActive(false);


            //enable sound and spotlight for eyescanner
            audioForObject[0].enabled = true;
            audioForObject[1].enabled = true;
            lightForObject[2].SetActive(true);

        }
        if (doorOpen[2])
        {

            audioForObject[0].gameObject.transform.GetChild(0).gameObject.GetComponent<Light>().color = Color.green;
            audioForObject[1].gameObject.transform.GetChild(0).gameObject.GetComponent<Light>().color = Color.green;


            //disable sound and spotlight for eyescanner
            audioForObject[0].enabled = false;
            audioForObject[1].enabled = false;
            lightForObject[2].SetActive(false);

            //enable sound and light for hand scanner
            audioForObject[2].enabled = true;
            lightForObject[3].SetActive(true);

            teleportplanes[1].SetActive(true);
            doors[3].GetComponent<Renderer>().materials[3].color = doorlight[0];
            doors[3].GetComponent<Renderer>().materials[4].color = doorlight[0];
            doors[3].GetComponent<Animator>().SetBool("opening", true);
        }
      
        
    }

}
