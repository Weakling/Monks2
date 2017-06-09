using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public GameObject Player01;
	public GameObject Player02;
	
	public float moveSpeed;

    private Rigidbody2D myRigidbody2D;

    // animation
    private Animator myAnimator;

	public bool lunge01;
	public bool lunge02;
	public bool banished01;
	public bool banished02;
	
	public Transform p1Start;
	public Transform p1End;
	public Transform p1Banished;
	public Transform p2Start;
	public Transform p2End;
	public Transform p2Banished;


    void Awake()
    {
        myAnimator = GetComponent<Animator>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start () 
	{

		lunge01 = false;
		lunge02 = false;
		p1Start.transform.position = Player01.transform.position;
		p2Start.transform.position = Player02.transform.position;
	}
	
	void Update () 
	{
		
	}


}
