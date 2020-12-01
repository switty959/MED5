using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingFromHeadset : MonoBehaviour
{
    public Camera main;
    public string tagLookingFor;
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
        if (_selection != null)
        {
            Renderer selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material.color = Color.grey;
            _selection = null;
        }

        Ray ray =  new Ray(main.transform.position,main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray,out hit))
        {
            Transform selection = hit.transform;
            if (selection.CompareTag(tagLookingFor))
            {
                Renderer selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material.color = Color.green;
                }
                _selection = selection;
            }
        }
        Debug.DrawRay(main.transform.position,main.transform.forward,Color.black,1);
    }
}
