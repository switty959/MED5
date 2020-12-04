using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingFromHeadset : MonoBehaviour
{
    public Camera main;
    public string tagLookingFor;
    public float totalTimeSpent;
    public float[] lookTimeForObject;
    public GameObject[] interactiveObjects;

    public Transform _selection;
    


    private void Awake()
    {
        lookTimeForObject = new float[interactiveObjects.Length];
        main = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }



    // Update is called once per frame
    void Update()
    {
        totalTimeSpent += Time.deltaTime;
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
        Debug.DrawRay(main.transform.position,main.transform.forward,Color.black,1);
    }
}
