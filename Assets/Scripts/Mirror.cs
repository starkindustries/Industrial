using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour, Interactable
{    
    public int state = 0; // 0=left, 1=up, 2=right, 3=down
    public float speed = 10f;

    private float[] targetRotation = { 0, 90, 180, 270 };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rotation = Quaternion.AngleAxis(targetRotation[state], Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
    }

    public void Toggle()
    {
        state += 1;
        state = (state < 4) ? state : 0;
    }    
}
