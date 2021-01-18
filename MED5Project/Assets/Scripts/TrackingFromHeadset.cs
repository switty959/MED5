using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;
using System.IO;

public class TrackingFromHeadset : MonoBehaviour
{
    public Camera main;
    public string tagLookingFor;
    public float totalTimeSpent;
    public float[] lookTimeForObject;
    public float[] intervalTimer;
    public bool[] triggersForIntervalTime;
    public GameObject[] interactiveObjects;
    public GameObject endScene;
    int textCounter;

    public Transform _selection;



    private void Awake()
    {
        lookTimeForObject = new float[interactiveObjects.Length];
        intervalTimer = new float[interactiveObjects.Length];
        triggersForIntervalTime = new bool[interactiveObjects.Length];
        main = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        totalTimeSpent += Time.deltaTime;

       for (int i = 0; i < triggersForIntervalTime.Length; i++)
        {
            if (!triggersForIntervalTime[i])
            {
                intervalTimer[i] = totalTimeSpent;
            }            
        }

        if (triggersForIntervalTime[interactiveObjects.Length-1])
        {
           
           StartCoroutine(writeFile());
        }


        Ray ray =  new Ray(main.transform.position,main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray,out hit))
        {
            Transform selection = hit.transform;
            if (selection.CompareTag(tagLookingFor))
            {
                for (int i = 0; i < interactiveObjects.Length; i++)
                {
                    if (selection.name == interactiveObjects[i].name)
                    {
                        lookTimeForObject[i] += Time.deltaTime;
                    }
                }
            }
        }
       
    }

    IEnumerator writeFile()
    {
        string path = Application.dataPath + "/TestData.txt";
        if (!File.Exists(path))
        {
            File.WriteAllText(path,"DataSet from Test \n\n");
        }
        File.AppendAllText(path, "------------------------------------------------\n");
        File.AppendAllText(path, "Total time spent: " + totalTimeSpent.ToString()+ "\n\n");

        for (int i = 0; i < interactiveObjects.Length; i++)
        {
            File.AppendAllText(path, "Time looked at "+interactiveObjects[i].name +": " + lookTimeForObject[i].ToString() + "\n");
        }

        File.AppendAllText(path, "\n");
        for (int i = 0; i < interactiveObjects.Length; i++)
        {
            if (i == 0)
            {
                File.AppendAllText(path, "interval time " + i + ": " + intervalTimer[i].ToString() + "\n");
            }
            else
            {
                float intervalTime = intervalTimer[i] - intervalTimer[i - 1];
                File.AppendAllText(path, "interval time " + i + ": " + intervalTime.ToString() + "\n");
            }
            
        }
        yield return new WaitForSeconds(5);
        Time.timeScale = 0;
        endScene.SetActive(true);
        //EditorApplication.isPlaying = false;
        //Application.Quit();
        
        
    }
}
