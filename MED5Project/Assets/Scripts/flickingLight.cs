using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flickingLight : MonoBehaviour
{
    // sound soure http://freesoundeffect.net/sound/fluorescent-light-flicker-za01-288-sound-effect
    Light lightSource;
    public AudioSource flickingLightSound;
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
            flickingLightSound.Play(0);
        }
    }
}
