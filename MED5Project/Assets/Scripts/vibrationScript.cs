using Packages.Rider.Editor.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class vibrationScript : MonoBehaviour
{
    public Vector3 startPos;
    public Quaternion startRotation;
    public AudioClip vibrationSound;    
    public float speed, strength,intensity;
    float timer;
    public bool vibrate;
    int test = 0;
    //speed is how fast it should move and strength is the amount it shoud move
    // Start is called before the first frame update
    void Awake()
    {
        startPos = transform.position;
        startRotation = transform.rotation;
        GetComponent<AudioSource>().clip = vibrationSound;
        timer = GetComponent<AudioSource>().clip.length;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vibrate)
        {
            StartCoroutine(vibration());
            
            if (test == 0)
            {
                GetComponent<AudioSource>().PlayOneShot(vibrationSound);
                test++;
            }
            

            
        }
        
    }

    IEnumerator vibration()
    {
        
        transform.rotation = new Quaternion(
            startRotation.x + Random.Range(-intensity, intensity) * intensity,
            startRotation.y + Random.Range(-intensity, intensity) * intensity,
            startRotation.z + Random.Range(-intensity, intensity) * intensity,
            startRotation.w + Random.Range(-intensity, intensity) * intensity
            ); 
        float x = Random.Range(startPos.x, startPos.x * Mathf.Sin(Random.Range(0, 1) * speed) * strength);
        float z = Random.Range(startPos.z, startPos.z * Mathf.Sin(Random.Range(0, 1) * speed) * strength);

        transform.position = new Vector3(x, startPos.y, z);


        
        yield return new WaitForSeconds(timer);
        vibrate = false;
        test=0;


    }
}
