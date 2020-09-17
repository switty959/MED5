using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public Vector3 scaleVector;
    public Matrix4x4 scaleMatrix;
    public Spawn_BorgShips shipListLength;
    // Start is called before the first frame update
    void Start()
    {
       
            
       
    }

    // Update is called once per frame
    void Update()
    {
        scaleMatrix.m00 = transform.localScale.x + scaleVector.x;
        scaleMatrix.m11 = transform.localScale.y + scaleVector.y;
        scaleMatrix.m22 = transform.localScale.z + scaleVector.z;
        transform.localScale = new Vector3(scaleMatrix.m00, scaleMatrix.m11, scaleMatrix.m22);
    }
}
