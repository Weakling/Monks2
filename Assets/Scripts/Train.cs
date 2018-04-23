using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour {

    

    public bool leaving, spawning;
    public float speed;
    public Transform spawnDestination;
    private Animator animator;
    private float deathTimer;

    void Awake()
    {
        deathTimer = 10;
        leaving = false;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (leaving)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            deathTimer -= Time.deltaTime;
            if(deathTimer <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        if (spawning)
        {
            if (transform.position.x > spawnDestination.position.x - speed * Time.deltaTime)
            {
                transform.position = new Vector2(spawnDestination.position.x, transform.position.y);
                spawning = false;
                leaving = false;
                animator.SetBool("Go", false);
            }
        }
    }

    public void Leave()
    {
        leaving = true;
        spawning = false;
        animator.SetBool("Go", true);
    }

    public void Spawn()
    {
        leaving = true;
        spawning = true;
        animator.SetBool("Go", true);
    }
}