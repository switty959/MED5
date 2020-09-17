    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;


public class moveShips : MonoBehaviour
{
    public Vector3 newPos;
    public GameObject objectToOrbit;
    public Spawn_BorgShips shipListLength;
    public float speed;
    public Matrix4x4 m ;
    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < shipListLength.ships.Count; i++)
        {
            m.m03 = (shipListLength.ships[i].transform.position.x + objectToOrbit.transform.position.x*2);
            m.m13 = (shipListLength.ships[i].transform.position.y + objectToOrbit.transform.position.y);
            m.m23 = (shipListLength.ships[i].transform.position.z + objectToOrbit.transform.position.z);
            shipListLength.ships[i].transform.position = new Vector3(m.m03, m.m13, m.m23);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
       

    }

    
}
