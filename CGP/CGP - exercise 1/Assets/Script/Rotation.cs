using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.Mathematics;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Vector4 Rotate;
    public Vector4 speed;
    Matrix4x4 m;
    private void Start()
    {
        
    }
    private void Update()
    {

        transform.rotation = quaternion.Euler(rotateAroundItSelves(transform));
        Rotate = new Vector4(Rotate.x+speed.x, Rotate.y+speed.y, Rotate.z+speed.x, Rotate.w+speed.w);
    }
   
    public Vector3 rotateAroundItSelves(Transform rotationY)
    {

        float radY = rotationY.rotation.y * Mathf.Deg2Rad; 
        m.m11 = 1;

        m.m00 = Mathf.Cos(radY); // for x axis, cos(d)
        m.m02 = Mathf.Sin(radY); // for x axis, sin(d)



        m.m20 = -1 * Mathf.Sin(radY); // for z axis, -sin(d)
        m.m22 = Mathf.Cos(radY); // for z axis, cos(d)

        //float xrow = (m.m00 + m.m02) * Rotate.y;
        //float zrow = (m.m22 + m.m20) * Rotate.y;
        //float yrow = m.m33 * Rotate.y;

        float xrow = (Rotate.x * m.m00) + (Rotate.y * m.m01) + (Rotate.z * m.m02);
        float yrow = (Rotate.x * m.m10) + (Rotate.y * m.m11) + (Rotate.z * m.m12);
        float zrow = (Rotate.x * m.m20) + (Rotate.y * m.m21) + (Rotate.z * m.m22);


        Vector3 newRotation = new Vector3(xrow,yrow,zrow);
        
        return newRotation;
    }

    


}
