using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorChecker : MonoBehaviour
{
    public int testprep; // 0 = baseline , 1 = light only, 2 = sound only, 3 = sound + light
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
        
    }
    void Start()
    {
        doorOpen = new bool[doors.Length];
        teleportplanes[7].SetActive(true);
        teleportplanes[8].SetActive(true);
        if (testprep ==0)
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
       
    }

    // Update is called once per frame
    void Update()
    {
       

        if (doorOpen[0])
        {
            teleportplanes[0].SetActive(true);
            teleportplanes[2].SetActive(true);

            doors[0].GetComponent<Renderer>().materials[3].color = doorlight[0];
            doors[0].GetComponent<Renderer>().materials[4].color = doorlight[0];
            doors[0].GetComponent<Animator>().SetBool("opening", true);

            doors[2].GetComponent<Renderer>().materials[3].color = doorlight[0];
            doors[2].GetComponent<Renderer>().materials[4].color = doorlight[0];
            doors[2].GetComponent<Animator>().SetBool("opening", true);
        }
        if (doorOpen[1])
        {
            teleportplanes[3].SetActive(true);

            doors[1].GetComponent<Renderer>().materials[3].color = doorlight[0];
            doors[1].GetComponent<Renderer>().materials[4].color = doorlight[0];
            doors[1].GetComponent<Animator>().SetBool("opening", true);


            audioForObject[0].gameObject.transform.GetChild(0).gameObject.GetComponent<Light>().color = Color.green;
            audioForObject[1 ].gameObject.transform.GetChild(0).gameObject.GetComponent<Light>().color = Color.green;
        }
        if (doorOpen[2])
        {
            teleportplanes[1].SetActive(true);
            doors[3].GetComponent<Renderer>().materials[3].color = doorlight[0];
            doors[3].GetComponent<Renderer>().materials[4].color = doorlight[0];
            doors[3].GetComponent<Animator>().SetBool("opening", true);
        }
        
    }

}
