using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElderLeft : MonoBehaviour {


    public Transform elderRise, elderSink;
    public float speed;



	void Start () {
		
	}
	
	void Update ()
    {
		


	}

    public void Sink()
    {
        transform.position = Vector3.MoveTowards(transform.position, elderSink.transform.position, speed * Time.deltaTime);
    }

    public void Rise()
    {
        transform.position = Vector3.MoveTowards(transform.position, elderRise.transform.position, speed * Time.deltaTime);
    }




}
