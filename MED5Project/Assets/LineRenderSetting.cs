﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineRenderSetting : MonoBehaviour
{
    [SerializeField] LineRenderer rend;
    Vector3[] points;

    public LayerMask layerMask;
    public Image img;
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

        img = panel.GetComponent<Image>();

    }
    private void Update()
    {
        AlignLineRenderer(rend);
        if (AlignLineRenderer(rend)&& Input.GetAxis("Sumbit")>0)
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
                img.color = Color.red;
                Debug.Log("RED");
            }
            else if (btn.name == "blue_btn")
            {
                img.color = Color.blue;
                Debug.Log("BLUE");
            }
            else if (btn.name == "green_btn")
            {
                img.color = Color.green;
                Debug.Log("GREEN");
            }
        }
    }
}
