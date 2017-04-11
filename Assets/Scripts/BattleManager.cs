using UnityEngine;
using System.Collections;

public class BattleManager : MonoBehaviour {

	// reference classes
	private HealthManager healthManager;
	private ElderMonk elderMonk;
	private HiddenText hiddenText;
	private PlayerController playerController;

	// animation
	public GameObject Player01;
	public GameObject Player02;
	private Rigidbody2D body02;
	private Animator anim01;
	private Animator anim02;

    // damage var
    public int playerDamageToGive;      // player's damage
	public int elderMonkDamageToGive;   // elder's damage
	private bool watching;              // is elder watching
    public static bool watching01;      // elder01 is watching
    public static bool watching02;      // elder02 is watching

    // round end
    public static bool roundEnd;               // in between rounds
	public float roundResetTime;        // time between rounds
	public float roundResetTimeCounter; // time variable between rounds

	void Start () 
	{
		//instantiate reference classes
		healthManager = FindObjectOfType<HealthManager> ();
		elderMonk = FindObjectOfType<ElderMonk> ();
		hiddenText = FindObjectOfType<HiddenText> ();
		playerController = FindObjectOfType<PlayerController> ();

		//find animators
		anim01 = Player01.GetComponent<Animator> ();
		anim02 = Player02.GetComponent<Animator> ();

		//player02 rigidbody
		body02 = Player02.GetComponent<Rigidbody2D> ();

		//set starting values
		roundEnd = false;
		roundResetTimeCounter = roundResetTime;
	}
	
	void Update () 
	{

		
		if(roundEnd)                    // round end check
        {   
			UseClock();                 // 
			hiddenText.roundEndTurnOn();
		}
		else
		{
			hiddenText.roundEndTurnOff();
		}
        //is watching var update
        if (watching01 || watching02)
            watching = true;
        else
            watching = false;

		//player 01 deals attack damage
		if(Input.GetKeyDown(KeyCode.D) && !watching && !roundEnd) 
		{
			//give damage
			healthManager.P2TakeDamage(playerDamageToGive);

			//movement
			playerController.lunge01 = true;

			//attack animation
			anim01.SetBool ("attacking", true);
			Hurt02 ();

			//que round end
			roundEnd = true;
		}
		//player 02 deals attack damage
		if (Input.GetKeyDown(KeyCode.L) && !watching && !roundEnd)
		{
			//give damage
			healthManager.P1TakeDamage(playerDamageToGive);

			//movement
			playerController.lunge02 = true;

			//attack animation
			anim02.SetBool ("attacking", true);
			Hurt01 ();
			
			//que round end
			roundEnd = true;
		}

		//player 01 gets caught
		if (Input.GetKeyDown (KeyCode.D) && watching && !roundEnd)
		{
			//give damage
			healthManager.P1TakeDamage(elderMonkDamageToGive);

			//movement
			playerController.banished01 = true;

			//hurt animation
			anim01.SetBool ("hurt", true);
			Hurt01();

			//que round end
			roundEnd = true;
		}
		//player 02 gets caught
		if (Input.GetKeyDown(KeyCode.L) && watching && !roundEnd)
		{
			//give damage
			healthManager.P2TakeDamage(elderMonkDamageToGive);

			//movement
			playerController.banished02 = true;

			//hurt animation
			Hurt02 ();
			
			//que round end
			roundEnd = true;
		}

	}

	//helper methods

	//count down timer
	private void UseClock()
	{
		roundResetTimeCounter -= Time.deltaTime;
		if(roundResetTimeCounter <= 0)
		{
			//reset cool down
			roundResetTimeCounter = roundResetTime;
			//end countdown
			roundEnd = false;
			//reset positions
			playerController.lunge01 = false;
			playerController.lunge02 = false;
			playerController.banished01 = false;
			playerController.banished02 = false;
			//set anims to idle
			anim01.SetBool("attacking", false);
			anim01.SetBool("hurt", false);
			anim02.SetBool("attacking", false);
			anim02.SetBool("hurt", false);
		}
	}
	

	private void Hurt01()
	{
		anim01.SetBool ("hurt", true);
	}

	private void Hurt02()
	{
		anim02.SetBool ("hurt", true);
	}


}