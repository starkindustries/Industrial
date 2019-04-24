using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour, Interactable
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Animator animator;
    public bool isFiring = false;
    public float timeBetweenShots = 1.0f;
    private bool onCooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFiring && !onCooldown)
        {
            Fire();
            animator.SetTrigger("Fire");
            onCooldown = true;
            StartCoroutine("DelayBetweenShots");
        }
    }

    IEnumerator DelayBetweenShots()
    {        
        yield return new WaitForSeconds(timeBetweenShots);
        onCooldown = false;
    }

    public void Fire()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void Interactable.Toggle()
    {
        Debug.Log("MachineGun detected player interaction!");
        isFiring = !isFiring;
    }    
}
