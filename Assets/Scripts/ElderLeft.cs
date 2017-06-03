using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElderLeft : MonoBehaviour {

    public Transform elderRise, elderSink;
    public float speed;
    private int elderMovement = 0;

	void Update ()
    {
		if(elderMovement == 1)
        {
            Sink();
        }
        else if(elderMovement == 2)
        {
            Rise();
        }
	}

    public void Sink()
    {
        elderMovement = 1;
        transform.position = Vector3.MoveTowards(transform.position, elderSink.transform.position, speed * Time.deltaTime);
    }

    public void Rise()
    {
        elderMovement = 2;
        transform.position = Vector3.MoveTowards(transform.position, elderRise.transform.position, speed * Time.deltaTime);
    }

}
