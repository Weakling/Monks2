using UnityEngine;
using System.Collections;

public class ElderMonk : MonoBehaviour {

	

	// other classes
	//private BattleManager battleManager;    // var
	//public bool roundEnd;                   // battle manager is round over

	// watching
    [SerializeField] private bool iAmElder01;         // is elder01
    [SerializeField] private bool iAmElder02;         // is elder02
	[SerializeField] private bool canLookAway;        // can look away
	[SerializeField] private int isWatchingChance;    // chance of looking away
	[SerializeField] private int currentActionChance; // which active action

	// animation
	private Animator anim;          // component
    private SpriteRenderer sprite;  // component
    public Transform elderStart;    // component
    public Transform elderStart01;  // component
    public Transform elderStart02;  // component

    private Rigidbody2D myRigidbody2D;  // component
	public float moveSpeedPatrol;       // max normal move speed
	public float moveSpeedRoundEnd;     // max elder reset move speed
	public float moveVelocity;          // applied move speed

	// time
	private bool readyToAct;            // loop of actions bool
	private bool useCoolDownClock;
	public float transitionTime;        // time spent in current state
	public float transitionTimeMin;     // min time random range
	public float transitionTimeMax;     // max time random range
	
	// states
	private bool faceAway;
	private bool walkRight;
	private bool walkLeft;
	private bool faceForward;

	void Start ()
	{
		// find other classes
		//battleManager = FindObjectOfType<BattleManager> ();
        
        // get components
		anim = GetComponent<Animator> ();
		myRigidbody2D = GetComponent<Rigidbody2D> ();
        sprite = GetComponent<SpriteRenderer>();

        // set vars
        moveVelocity = 0;           // starts with no applied move velocity
		canLookAway = false;        // starts each round watching

        // set object to correct elder watching number
        // starts each round watching
        if (iAmElder01)                         
            BattleManager.watching01 = true;
        else if (iAmElder02)
            BattleManager.watching02 = true;
        
        //cool down
        transitionTime = 2;         // first action of the round lasts 2 seconds
		readyToAct = true;          // can enter loop of actions
		useCoolDownClock = false;   // random action cooldown time not started
	}


	void Update () 
	{
		//check for round end
		//roundEnd = battleManager.roundEnd;

		//reset
		if(BattleManager.roundEnd)            // end of round
		{
			ElderReset();       // elder returns to start position
			transitionTime = 0;   
			UseClock ();
			return;
		}

        // set proper sprite inversion
        if (moveVelocity > 0)
            sprite.flipX = true;
            //myRigidbody2D.transform.localScale = new Vector3 (-1f, 1f, 1f);
        else
            sprite.flipX = false;
			//myRigidbody2D.transform.localScale = new Vector3 (1f, 1f, 1f);

		// movement
		myRigidbody2D.velocity = new Vector2 (moveVelocity, myRigidbody2D.velocity.y);

		// loop of actions
		if(readyToAct) 
		{
			// elder starts the round watching
			if(canLookAway)
			{
				isWatchingChance = Random.Range(0, 4); // chance to be watching
                                                       // chance to look away is 1 in x
			}
            // can't look away (start)...
			else if(!canLookAway)
			{
                // skips not watching chance
                isWatchingChance = 1;
			}

			// decide elder action
			if(isWatchingChance == 0)   // this is skipped if !canLookAway
			{
                // not watching
                if (iAmElder01)
                    BattleManager.watching01 = false;
                else if (iAmElder02)
                    BattleManager.watching02 = false;

				// anim face away
				moveVelocity = 0;                  // stop movement
				anim.SetBool("away", true);        // anim set 
				anim.SetBool ("walk", false);      // anim false
				anim.SetBool ("forward", false);   // anim false
				Debug.Log("face away");            // debug log

				// disable new action loops until clock is done
				WaitPlease();
			}
			else
			{
                // is watching
                if (iAmElder01)
                    BattleManager.watching01 = true;    // is watching
                else if (iAmElder02)
                    BattleManager.watching02 = true;
				canLookAway = true;       // watching face state can roll
				WaitPlease();             // disable future update state checks until clock is done

                currentActionChance = Random.Range (0,3); // choose current action
                if (currentActionChance == 0)
				{
                    // walk right
                    moveVelocity = moveSpeedPatrol;
					anim.SetBool ("walk", true);
					anim.SetBool ("away", false);
					anim.SetBool ("forward", false);
					Debug.Log ("walk right");
				}
				else if(currentActionChance == 1)
				{
					// walk left
					moveVelocity = -moveSpeedPatrol;
					anim.SetBool ("walk", true);
					anim.SetBool ("away", false);
					anim.SetBool ("forward", false);
					Debug.Log ("walk left");
				}
				else if(currentActionChance == 2)
				{
					// face forward
					moveVelocity = 0;
					anim.SetBool ("forward", true);
					anim.SetBool ("walk", false);
					anim.SetBool ("away", false);
					Debug.Log("face forward");
				}
			}
		}

		// cue action delay
		if(useCoolDownClock)
		{
			UseClock ();
		}
	}

	private void WaitPlease()
	{
		readyToAct = false;
		useCoolDownClock = true;
	}

	// action delay
	private void UseClock()
	{
		transitionTime -= Time.deltaTime; // subtract time
		if(transitionTime <= 0)           // if time is up
		{
            // reset transition time
			transitionTime = Random.Range(transitionTimeMin, transitionTimeMax);
            // allow loop of actions
			readyToAct = true;
			// end countdown
			useCoolDownClock = false;
		}
	}

	private void ElderReset()
	{
		if(anim.GetBool("forward") == false)
		{
			anim.SetBool ("forward", true);
			anim.SetBool ("walk", false);
			anim.SetBool ("away", false); 
		}
        // return to start position
        if (PlayerPrefs.GetInt("ElderCount") == 1)
        {
            myRigidbody2D.transform.position = Vector3.MoveTowards
                (myRigidbody2D.transform.position, elderStart.position, Time.deltaTime * moveSpeedRoundEnd);
        }
        // 2 monks find monk 01
        else if (gameObject.name == "ElderMonk01")
        {
            myRigidbody2D.transform.position = Vector3.MoveTowards
                (myRigidbody2D.transform.position, elderStart01.position, Time.deltaTime * moveSpeedRoundEnd);
        }
        // 2 monks find monk 02
        else if (gameObject.name == "ElderMonk02")
        {
            myRigidbody2D.transform.position = Vector3.MoveTowards
                (myRigidbody2D.transform.position, elderStart02.position, Time.deltaTime * moveSpeedRoundEnd);
        }
        // set elder to watching
        canLookAway = false;
	}
}