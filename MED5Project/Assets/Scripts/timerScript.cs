using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerScript : MonoBehaviour
{

    public bool countdown, timer;
    public float counter;

    public int maxtime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (countdown && !timer)
        {
            countdownFunction(maxtime);
        }
        if (!countdown && timer)
        {
            timerFunction();
        }
       
    }
    void countdownFunction( float maxTime)
    {
        counter = maxTime;
        counter -= Time.deltaTime;
        if (counter<0)
        {
            Debug.Log("The time is up");
        }
    }

    void timerFunction()
    {
        counter = Time.time;
    }
}
