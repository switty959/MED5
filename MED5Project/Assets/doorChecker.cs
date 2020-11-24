using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorChecker : MonoBehaviour
{
    public bool[] doorOpen;
    public GameObject[] doors = new GameObject[5];
    public Color[] doorlight = new Color[2];
    // Start is called before the first frame update
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
            }
            else
            {
                doors[i].GetComponent<Renderer>().materials[3].color = doorlight[1];
                doors[i].GetComponent<Renderer>().materials[4].color = doorlight[1];
                doors[i].GetComponent<Animator>().SetBool("opening", false);
            }
        }   
    }
}
