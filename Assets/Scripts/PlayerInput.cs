using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerInput
{
    public static bool IsPressingJump()
    {
        return CrossPlatformInputManager.GetButtonDown("Jump");
        // return Input.GetButtonDown("Jump");
    }

    public static bool IsPressingShoot()
    {

        return CrossPlatformInputManager.GetButtonDown("Fire1");
        // return Input.GetButtonDown("Fire1");
    }

    public static bool IsPressingSwipe()
    {
        return Input.GetButtonDown("Fire2");
    }

    public static float HorizontalAxis()
    {
        return CrossPlatformInputManager.GetAxis("Horizontal");
    }
}
