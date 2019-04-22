using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public float runSpeed = 40f;
    public Animator animator;
    public Transform firePoint;
    public GameObject bulletPrefab;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;        
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));          // Speed is the name of the parameter in the animator object

        // Jumping
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        // Crouching
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        // Shooting
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Got fire1 button");
            animator.SetTrigger("Attack");
            Shoot();
        }

        // Swiping
        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Got fire2 button");
            animator.SetTrigger("Swipe");
        }
    }

    // Use FixedUpdate for physics stuff
    private void FixedUpdate()
    {
        // Move character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
