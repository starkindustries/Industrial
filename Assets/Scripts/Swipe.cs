using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        // If other is interactable then toggle it
        Interactable interactableObject = other.GetComponent<Interactable>();
        if (interactableObject != null)
        {
            Debug.Log("Swipe triggered: " + other.gameObject.name);
            interactableObject.Toggle();
        }
    }
}
