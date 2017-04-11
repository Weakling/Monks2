using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public GameObject Player01;
	public GameObject Player02;
	private Rigidbody2D body02;
	public float moveSpeed;

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

	// Use this for initialization
	void Start () 
	{
		//player02 rigidbody
		body02 = Player02.GetComponent<Rigidbody2D> ();

		//player02 direction face
		body02.transform.localScale = new Vector3 (-1f, 1f, 1f);


		lunge01 = false;
		lunge02 = false;
		p1Start.transform.position = Player01.transform.position;
		p2Start.transform.position = Player02.transform.position;
	}
	
	void Update () 
	{
		//player01 attack movement
		if (lunge01) 
		{
			Player01.transform.position = Vector3.MoveTowards
				(Player01.transform.position, p1End.position, Time.deltaTime * moveSpeed);
		} 
		else if(!lunge01 && !banished01) 
		{
			Player01Reset();
		}

		//player01 banished
		if (banished01) 
		{
			Player01.transform.position = Vector3.MoveTowards
				(Player01.transform.position, p1Banished.position, Time.deltaTime * moveSpeed);
		}
		else if(!lunge01 && !banished01) 
		{
			Player01Reset();
		}
		//player02 attack movement
		if (lunge02) 
		{
			Player02.transform.position = Vector3.MoveTowards
				(Player02.transform.position, p2End.position, Time.deltaTime * moveSpeed);
		} 
		else if(!lunge02 && !banished02) 
		{
			Player02Reset();
		}

		//player02 banished
		if (banished02) 
		{
			Player02.transform.position = Vector3.MoveTowards
				(Player02.transform.position, p2Banished.position, Time.deltaTime * moveSpeed);
		} 
		else if (!lunge02 && !banished02) 
		{
			Player02Reset();
		}
	}

	private void Player01Reset()
	{
		Player01.transform.position = Vector3.MoveTowards 
			(Player01.transform.position, p1Start.position, Time.deltaTime * moveSpeed);
	}

	private void Player02Reset()
	{
		Player02.transform.position = Vector3.MoveTowards 
			(Player02.transform.position, p2Start.position, Time.deltaTime * moveSpeed);
	}
}
