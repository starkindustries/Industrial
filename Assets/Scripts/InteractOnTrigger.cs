using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class InteractOnTrigger: MonoBehaviour
{
    public UnityEvent OnEnter;
    public UnityEvent OnExit;

    void OnTriggerEnter2D(Collider2D other)
    {
        OnEnter.Invoke();        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        OnExit.Invoke();
    }    
}