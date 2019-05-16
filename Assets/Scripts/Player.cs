using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, Damageable
{

    public CharacterController2D controller;
    public float runSpeed = 40f;
    public Animator animator;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject splatEffect;

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
        GameManager manager = FindObjectOfType<GameManager>();
        if(manager.IsPaused() || manager.IsGameOver())
        {
            return;
        }

        horizontalMove = PlayerInput.HorizontalAxis() * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));      // Speed is the name of the parameter in the animator object

        // Jumping
        if (PlayerInput.IsPressingJump())
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
        if (PlayerInput.IsPressingShoot())
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

    void Damageable.Damage()
    {
        Debug.Log("Player took damage!!");
        Instantiate(splatEffect, transform.position, transform.rotation);
        FindObjectOfType<GameManager>().GameOver();
        Destroy(this.gameObject);
    }
}
