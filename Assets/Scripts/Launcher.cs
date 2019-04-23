using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public SpriteRenderer launcherDown;
    public SpriteRenderer launcherUp;
    public float launchSpeed;
    public bool launcherIsDown = true;
    public float resetDelay = 1.0f;
    private bool enabled = true;

    public void Start()
    {
        UpdateLaunchPad(launcherIsDown);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!enabled)
        {
            return;
        }

        if(launcherIsDown)
        {
            // Launch the object upwards
            Debug.Log("Launching object tag: " + other.tag);
            other.attachedRigidbody.velocity = new Vector2(x: other.attachedRigidbody.velocity.x, y: launchSpeed);
            // other.attachedRigidbody.AddForce(new Vector2(0f, launchSpeed));

            // Change the pad state to up            
            launcherIsDown = false;
            UpdateLaunchPad(launcherIsDown);
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
        launcherIsDown = true;
        UpdateLaunchPad(launcherIsDown);
    }    

    public void Toggle()
    {
        enabled = !enabled;
    }
}
