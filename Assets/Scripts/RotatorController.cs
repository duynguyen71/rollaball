using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorController : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        Vector3 vector = new Vector3(15, 30, 45) * Time.deltaTime;
        transform.Rotate(vector);
    }

    
}
