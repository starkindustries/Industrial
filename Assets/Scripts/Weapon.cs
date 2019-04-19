using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Animator animator;
    public Transform firePoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Got fire1 button");
            animator.SetTrigger("Attack");
            Shoot();
        }
    }

    void Shoot()
    {

    }
}
