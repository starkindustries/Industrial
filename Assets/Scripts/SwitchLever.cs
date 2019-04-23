using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchLever : MonoBehaviour, Interactable
{
    public Animator animator;
    public UnityEvent onToggle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Interactable.Toggle()
    {
        animator.SetTrigger("ToggleSwitch");
        onToggle.Invoke();
    }
}
