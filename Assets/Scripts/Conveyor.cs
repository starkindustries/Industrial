using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public GameObject conveyorBelt;
    public Transform endpoint;
    public float speed;
    public bool conveyorIsOn = true;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("Speed", speed);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!conveyorIsOn)
        {
            return;
        }

        if (other.tag == "SwipeHitbox")
        {
            // Ignore the swipe hitbox..
            Debug.Log("Conveyor collided with swipe hitbox.");
        }
        else
        {
            other.transform.position = Vector3.MoveTowards(other.transform.position, endpoint.position, speed * Time.deltaTime);
        }
    }

    public void TurnOn()
    {
        if (!conveyorIsOn)
        {
            animator.enabled = true;            
            conveyorIsOn = true;
        }
    }

    public void TurnOff()
    {
        if (conveyorIsOn)
        {
            animator.enabled = false;
            conveyorIsOn = false;
        }
    }

    public void Toggle()
    {
        Debug.Log("Toggle Conveyor.");
        if (conveyorIsOn)
        {
            TurnOff();
        }
        else
        {
            TurnOn();
        }
    }
}
