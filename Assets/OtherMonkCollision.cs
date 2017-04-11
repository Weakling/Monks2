using UnityEngine;
using System.Collections;

public class OtherMonkCollision : MonoBehaviour {

    private LayerMask baseMask;                     // default layermask var
    [SerializeField] private GameObject myMonk;     // elder this is attached to
    private ElderMonk moo;                          // elder script
    private bool monkCheck;                         // monk is in collision area

	void Start ()
    {
        baseMask = LayerMask.NameToLayer("default");    // find default layermask
        moo = myMonk.GetComponent<ElderMonk>();         // find elder script
        monkCheck = false;
    }

	void Update ()
    {
        // if detection transform collides with anything
        if (Physics2D.OverlapCircle(gameObject.transform.position, .01f, baseMask) && !monkCheck)
        {
            // elder turns around
            moo.moveVelocity = -moo.moveVelocity;
            monkCheck = true;
        }
        else
            monkCheck = false;

        // moving right
        if(moo.moveVelocity > 0)
        {
            // place collider right of parent
            transform.position = new Vector2 (myMonk.transform.position.x + 0.5f, transform.position.y);
        }
        // moving left
        else
        {
            // place collider left of parent
            transform.position = new Vector2(myMonk.transform.position.x - 0.5f, transform.position.y);
        }
    }
}
