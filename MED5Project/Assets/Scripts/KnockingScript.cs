using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockingScript : MonoBehaviour
{
    public AudioClip knockingSound;
    public bool knocking;
    int test;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (knocking)
        {
            StartCoroutine(knockingOnDoor());

            if (test == 0)
            {
                GetComponent<AudioSource>().PlayOneShot(knockingSound);
                test++;
            }


            



        }
    }
    IEnumerator knockingOnDoor()
    {
        yield return new WaitForSeconds(knockingSound.length);
        knocking = false;
        test = 0;
    }
}
