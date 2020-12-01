using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class LineRenderSetting : MonoBehaviour
{
    [SerializeField] LineRenderer rend;
    Vector3[] points;


    public SteamVR_Action_Boolean input;
    public LayerMask layerMask;
    public GameObject panel;
    public Button btn;
    
    private void Start()
    {
        rend = gameObject.GetComponent<LineRenderer>();

        points = new Vector3[2];

        points[0] = Vector3.zero;
        points[1] = transform.position + new Vector3(0, 0, 20);

        rend.SetPositions(points);

        rend.enabled = true;


    }
    private void Update()
    {
        AlignLineRenderer(rend);
        if (AlignLineRenderer(rend) && input.GetStateDown(SteamVR_Input_Sources.Any))
        {
            btn.onClick.Invoke();
        }
    }

    public bool AlignLineRenderer(LineRenderer rend)
    {
        bool hitBtn = false;
        Ray ray;
        ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray,out hit,layerMask))
        {
            points[1] = transform.forward + new Vector3(0, 0, hit.distance);

            rend.startColor = Color.red;
            rend.endColor = Color.red;
            btn = hit.collider.gameObject.GetComponent<Button>();
            hitBtn = true;
        }
        else
        {
            points[1] = transform.forward + new Vector3(0, 0, 20);
            rend.startColor = Color.green;
            rend.endColor = Color.green;
            hitBtn = false;
        }

        rend.material.color = rend.startColor;
        rend.SetPositions(points);
        return hitBtn;
    }

    public void ColorChangeOnClick() 
    {
        if (btn != null)
        {
            if (btn.name == "red_btn")
            {
                panel.GetComponent<MeshRenderer>().material.color = Color.red;
                Debug.Log("RED");
            }
            else if (btn.name == "blue_btn")
            {
                panel.GetComponent<MeshRenderer>().material.color = Color.blue;
                Debug.Log("BLUE");
            }
            else if (btn.name == "green_btn")
            {
                panel.GetComponent<MeshRenderer>().material.color = Color.green;
                Debug.Log("GREEN");
            }
        }
    }
}
