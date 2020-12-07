using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class doorChecker : MonoBehaviour
{
    public int testprep; // 0 = baseline , 1 = light only, 2 = sound only, 3 = sound + light
    public string testObjectName;

    public bool noSound, noLight = false;

    public bool[] doorOpen;

    public GameObject[] doors = new GameObject[4];
    public GameObject[] teleportplanes;
    public GameObject[] interactiveObjectWithChangingMaterials = new GameObject[2];
    public Color[] doorlight = new Color[2];
    public GameObject[] lightForObject = new GameObject[4];
    public AudioSource[] audioForObject = new AudioSource[4];
    public Material[] imagesForDigitalScreens = new Material[2];


    // Start is called before the first frame update

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
          audioForObject[i].mute = true ;
      }

      for (int i = 0; i < doors.Length; i++)
      {
          doors[i].GetComponent<Renderer>().materials[3].color = doorlight[1];
          doors[i].GetComponent<Renderer>().materials[4].color = doorlight[1];
      }



      teleportplanes[4].SetActive(true);
      teleportplanes[4].transform.GetChild(0).gameObject.SetActive(true);
      teleportplanes[4].transform.GetChild(1).gameObject.SetActive(true);

      //------------------for testing ---------------------------------//

      if (testprep == 0)
      {
            noSound = true;
            noLight = true;
      }
      if (testprep == 1)
      {
            noSound = true;
        }
      if (testprep == 2)
      {
            noLight = true;
      }
      for (int i = 0; i < audioForObject.Length; i++)
      {
          audioForObject[i].mute = true;
      }
      //------------------for testing ---------------------------------//

      lightForObject[0].SetActive(true);
      audioForObject[0].mute = false;
  }

  // Update is called once per frame
  void Update()
  {
        if (noSound)
        {
            for (int i = 0; i < audioForObject.Length; i++)
            {
                audioForObject[i].mute = true;
            }
        }
        if (noLight)
        {
            for (int i = 0; i < lightForObject.Length; i++)
            {
                lightForObject[i].SetActive(false);
            }
        }
        if (!noSound)
        {
            for (int i = 4; i < 7; i++)
            {
                audioForObject[i].mute = false;
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
            if (!noLight)
            {
                lightForObject[0].SetActive(false);     
            }
          
          interactiveObjectWithChangingMaterials[0].GetComponent<MeshRenderer>().material = imagesForDigitalScreens[0];

            //enable sound and light for dresser
            if (!noLight)
            {
                lightForObject[1].SetActive(true);
            }
          

      }
      if (doorOpen[1])
      {
          teleportplanes[3].SetActive(true);

          doors[1].GetComponent<Renderer>().materials[3].color = doorlight[0];
          doors[1].GetComponent<Renderer>().materials[4].color = doorlight[0];
          doors[1].GetComponent<Animator>().SetBool("opening", true);


            //disable sound and light for dresser
            


            //enable sound and spotlight for eyescanner
            if (!noLight)
            {
                lightForObject[2].SetActive(true);
                lightForObject[1].GetComponent<Animator>().SetBool("triggered", true);

                for (int i = 4; i < lightForObject.Length; i++)
                {
                    lightForObject[i].SetActive(true);
                }
            }

        }
      if (doorOpen[2])
      {




            //disable sound and spotlight for eyescanner
            if (!noLight)
            {
                lightForObject[2].SetActive(false);
                lightForObject[3].SetActive(true);
                for (int i = 4; i < lightForObject.Length; i++)
                {
                    lightForObject[i].GetComponent<Light>().color = Color.green;
                }
            }
          

          //enable sound and light for hand scanner

          

          teleportplanes[1].SetActive(true);
          doors[3].GetComponent<Renderer>().materials[3].color = doorlight[0];
          doors[3].GetComponent<Renderer>().materials[4].color = doorlight[0];
          doors[3].GetComponent<Animator>().SetBool("opening", true);
      }

      if (doorOpen[3])
      {
            //disable sound and spotlight for handscanner
            if (!noLight)
            {
                lightForObject[3].SetActive(false);
            }
         
          interactiveObjectWithChangingMaterials[1].GetComponent<MeshRenderer>().material = imagesForDigitalScreens[1];
      }



  }

}
