using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveShips : MonoBehaviour
{
    public Vector3 newPos;
    public Spawn_BorgShips shipListLength;
    public Matrix4x4 m;
    Vector3 meme = new Vector3( 1, 1, 1 );
    
    // Start is called before the first frame update
    void Start()
    {
        m[0, 3] = meme[0];
        m[1, 3] = meme[1];
        m[2, 3] = meme[2];
        Debug.Log(m);
        Debug.Log(m.MultiplyPoint(shipListLength.ships[0].transform.position));


    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < shipListLength.ships.Count; i++)
        {
            shipListLength.ships[i].transform.position = m.MultiplyPoint(shipListLength.ships[i].transform.position);
        }
        
    }
}
