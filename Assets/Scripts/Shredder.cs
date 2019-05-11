using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Damageable objectHit = other.gameObject.GetComponent<Damageable>();
        if (objectHit != null)
        {
            objectHit.Damage();
        }
    }
}
