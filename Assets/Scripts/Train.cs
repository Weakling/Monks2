using UnityEngine;
using System.Collections;

public class Train : MonoBehaviour {

	Rigidbody2D rb;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Random.value < .1) {
			rb.AddForce (new Vector2 (-100, 0));
		}
	}
}
