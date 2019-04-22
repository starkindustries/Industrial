using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public GameObject conveyorBelt;
    public Transform endpoint;
    public float speed = 10f;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "SwipeHitbox")
        {
            Debug.Log("Conveyor collided with swipe hitbox.");
        }
        else
        {
            other.transform.position = Vector3.MoveTowards(other.transform.position, endpoint.position, speed * Time.deltaTime);
        }        
    }
}
