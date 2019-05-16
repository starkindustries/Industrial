using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MukBot : MonoBehaviour, Damageable
{
    public GameObject splatEffect;

    void Damageable.Damage()
    {
        Debug.Log("Mukbot took damage!!");
        Instantiate(splatEffect, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
