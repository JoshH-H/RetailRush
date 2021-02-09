using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.left, 0.56f * Time.deltaTime);
        transform.LookAt(Vector3.zero);
    }
}
