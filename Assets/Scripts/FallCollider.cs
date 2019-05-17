using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCollider : MonoBehaviour
{    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Damageable objectHit = other.gameObject.GetComponent<Damageable>();
        if (objectHit != null)
        {
            objectHit.Damage();
        }
    }
}
