using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawn_BorgShips : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject borgShip;
    float newPosX = 2;
    float newPosY = 2;
    float newPosZ = 2;
    public Vector3 distanceBetweenCube;
    public int multiplier = 11;
    public float translate = 2;
    public List<GameObject> ships;
    void Awake()
    {
        for (int i = 0; i < multiplier; i++)
        {
            for (int j = 0; j < multiplier; j++)
            {
                for (int l = 0; l < multiplier; l++)
                {
                    newPosX = translate + translate * i;
                    newPosZ = translate + translate * j;
                    newPosY = translate + translate * l;
                    GameObject bob = Instantiate(borgShip, new Vector3(newPosX, newPosY, newPosZ), transform.rotation, gameObject.transform);
                    bob.GetComponent<Renderer>().material.color = new Color(1 * (0.1f * i), 1 * (0.1f * j), 1 * (0.1f * l));
                    ships.Add(bob);
                }
            }

        }

        
    }
    private void Update()
    {
       
    }


}
