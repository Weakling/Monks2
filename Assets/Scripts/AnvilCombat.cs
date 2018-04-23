using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilCombat : MonoBehaviour {

    public OptionsManager myOptionsManager;
    public float speed;

    private float lifeTime;
    private Rigidbody2D myRigidbody2D;

    private void Awake()
    {
        this.myRigidbody2D = GetComponent<Rigidbody2D>();

    }

    void Start ()
    {
        lifeTime = 2.5f;	
	}
	
	
	void Update ()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            myOptionsManager.anvilCanSet = true;
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        this.myRigidbody2D.velocity = new Vector2(0, -speed);
    }
}
