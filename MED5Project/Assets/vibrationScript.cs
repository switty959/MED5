using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class vibrationScript : MonoBehaviour
{
    public Vector3 startPos;
    public Quaternion startRotation;
    public AudioSource vibrationSound;
    public float speed, strength,intensity;
    public int timer;
    public bool vibrate;
    //speed is how fast it should move and strength is the amount it shoud move
    // Start is called before the first frame update
    void Awake()
    {
        startPos = transform.position;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (vibrate)
        {
            StartCoroutine(vibration());
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
        vibrationSound.Play();
        
        yield return new WaitForSeconds(timer);
        vibrate = false;


    }
}
