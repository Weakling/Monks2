using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainCombat : MonoBehaviour {

    public OptionsManager myOptionsManager;
    public float speed;
    public int leftRight;
    private float lifeTime;
    private Rigidbody2D myRigidBody2D;
    private Animator myAnimator;

    private void Awake()
    {
        this.myRigidBody2D = GetComponent<Rigidbody2D>();
        this.myAnimator = GetComponent<Animator>();
    }

    void Start ()
    {
        lifeTime = 4;
        if(leftRight == 1)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        //myAnimator.SetBool("Go", true);
    }
	
	void Update ()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)
        {
            myOptionsManager.trainCanSet = true;
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (leftRight == 0)
        {
            this.myRigidBody2D.velocity = new Vector2(speed, this.myRigidBody2D.velocity.y);
        }
        else if (leftRight == 1)
        {
            this.myRigidBody2D.velocity = new Vector2(-speed, this.myRigidBody2D.velocity.y);
        }
    }
}
