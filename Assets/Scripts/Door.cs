using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool doorIsOpen = false;
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Open()
    {
        if (!doorIsOpen)
        {
            animator.SetTrigger("ToggleDoor");
            doorIsOpen = true;
        }
    }

    public void Close()
    {
        if (doorIsOpen)
        {
            animator.SetTrigger("ToggleDoor");
            doorIsOpen = false;
        }
    }

    public void Toggle()
    {
        Debug.Log("Toggle Door.");
        if (doorIsOpen)
        {
            Close();
        }
        else
        {
            Open();
        }
    }
}
