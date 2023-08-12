using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningItem : MonoBehaviour
{

    public int maxObjToSpawn = 10;
    public GameObject gameObjPickItemPref;

    // Floor
    public GameObject floor;


    void Start()
    {

        Vector3 halfFloorSize = floor.GetComponent<MeshRenderer>().bounds.size / 2;
        float dimX = halfFloorSize.x;
        float dimZ = halfFloorSize.z;

        // Spawing item
        for (var i = 0; i < maxObjToSpawn; i++)
        {
            Instantiate<GameObject>(
                gameObjPickItemPref,
                new Vector3(Random.Range(-dimX, dimX), 0.5f, Random.Range(-dimZ, dimZ)),
                Quaternion.identity
            );
        }

    }

}
