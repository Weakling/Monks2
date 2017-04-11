using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

    [SerializeField] private GameObject elderMonk01;
    [SerializeField] private GameObject elderMonk02;
    private ElderMonk moo01;
    private ElderMonk moo02;


    void Start()
    {
        moo01 = elderMonk01.GetComponent<ElderMonk>(); // get script attached to elder01
        moo02 = elderMonk02.GetComponent<ElderMonk>(); // get script attached to elder02
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "ElderMonk01")
		{
			moo01.moveVelocity = -moo01.moveVelocity;
		}
        else if(other.name == "ElderMonk02")
        {
            moo02.moveVelocity = -moo02.moveVelocity;
        }
	}
}