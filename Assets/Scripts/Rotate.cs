using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed;
    public bool clockwise;    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 axis = clockwise ? Vector3.back : Vector3.forward;
        transform.Rotate(axis: axis, angle: speed * Time.deltaTime);        
    }
}
