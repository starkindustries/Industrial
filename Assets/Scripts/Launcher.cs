using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public SpriteRenderer launcherDown;
    public SpriteRenderer launcherUp;
    public float launchSpeed = 1000f;
    public bool launchPadIsDown = true;
    public float resetDelay = 1.0f;

    public void Start()
    {
        UpdateLaunchPad(launchPadIsDown);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(launchPadIsDown)
        {
            // Launch the object upwards
            Debug.Log("Launching object tag: " + other.tag);
            other.attachedRigidbody.AddForce(new Vector2(0f, launchSpeed));

            // Change the pad state to up            
            launchPadIsDown = false;
            UpdateLaunchPad(launchPadIsDown);
            StartCoroutine("ResetLaunchPad");            
        }        
    }

    private void UpdateLaunchPad(bool isDown)
    {
        launcherDown.enabled = isDown;
        launcherUp.enabled = !isDown;
    }

    IEnumerator ResetLaunchPad()
    {
        yield return new WaitForSeconds(resetDelay);
        launchPadIsDown = true;
        UpdateLaunchPad(launchPadIsDown);
    }    
}
