using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flickingLight : MonoBehaviour
{
    Light lightSource;
    public float minWaitTime, maxWaitTime;
    void Start()
    {
        lightSource = GetComponent<Light>();
        StartCoroutine(flickering());
    }
   



   IEnumerator flickering()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            lightSource.enabled = !lightSource.enabled;
        }
    }
}
