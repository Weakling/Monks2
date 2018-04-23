using UnityEngine;
using System.Collections;

public class BattleManager : MonoBehaviour {

	// reference classes
	//private HealthManager healthManager;
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
    //public int playerDamageToGive;      // player's damage
	//public int elderMonkDamageToGive;   // elder's damage
	private bool watching;              // is elder watching
    public static bool watching01;      // elder01 is watching
    public static bool watching02;      // elder02 is watching

    // round end
    public static bool roundEnd;        // in between rounds
	public float roundResetTime;        // time between rounds
	public float roundResetTimeCounter; // time variable between rounds

    void Awake()
    {

    }

    void Start () 
	{
		//instantiate reference classes
		//healthManager = FindObjectOfType<HealthManager> ();
		elderMonk = FindObjectOfType<ElderMonk> ();
		hiddenText = FindObjectOfType<HiddenText> ();
		playerController = FindObjectOfType<PlayerController> ();

		//set starting values
		roundEnd = false;
		roundResetTimeCounter = roundResetTime;
	}

    void Update()
    {
        // round end check
        if (roundEnd)
        {
            UseClock();
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

    }

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
}