﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anvil : MonoBehaviour {

    public bool falling, spawning;
    public float speed;
    public Transform spawnDestination;
    private float deathTimer;

    void Awake()
    {
        deathTimer = 3f;
        falling = false;
    }
	
	void Update ()
    {
	    if(falling)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
            deathTimer -= Time.deltaTime;
            if (deathTimer <= 0)
            {
                Destroy(this.gameObject);
            }
        }	
        if(spawning)
        {
            if (transform.position.y < spawnDestination.position.y + speed * Time.deltaTime)
            {
                transform.position = new Vector2(transform.position.x, spawnDestination.position.y);
                spawning = false;
                falling = false;
            }
        }
	}

    public void Leave()
    {
        falling = true;
        spawning = false;
    }

    public void Spawn()
    {
        falling = true;
        spawning = true;
    }

}
