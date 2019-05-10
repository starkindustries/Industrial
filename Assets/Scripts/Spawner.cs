using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawn;
    public bool isSpawning;
    public float timeBetweenSpawns;
    private bool onCooldown = false;


    // Start is called before the first frame update
    void Start()
    {
        
    } 

    void Update()
    {
        if (isSpawning && !onCooldown)
        {
            Spawn();
            onCooldown = true;
            StartCoroutine("DelayBetweenSpawns");
        }
    }

    IEnumerator DelayBetweenSpawns()
    {
        yield return new WaitForSeconds(timeBetweenSpawns);
        onCooldown = false;
    }

    public void Spawn()
    {
        Instantiate(spawn, transform.position, transform.rotation);
    }
}
