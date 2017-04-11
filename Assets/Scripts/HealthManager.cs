using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour 
{
	//other classes
	private GameOverManager gameOverManager;
	private HiddenText hiddenText;

	//player healths
	public Text P1Health;
	public Text P2Health;
	
	public int P1HealthCounter;
	public int P2HealthCounter;

    void Start()
    {
        //other classes
        gameOverManager = FindObjectOfType<GameOverManager>();
        hiddenText = FindObjectOfType<HiddenText>();
    }

    void Update () 
	{
		//set GUI health to current health
		P1Health.text = "" + P1HealthCounter;
		P2Health.text = "" + P2HealthCounter;
	}

	//give damage to player 01
	public void P1TakeDamage(int damageToGive)
	{
		//subtracts damage from health
		P1HealthCounter -= damageToGive;

		//sets negative health to zero
		if (P1HealthCounter <= 0)
		{
			P1HealthCounter = 0;
			//player 02 win screen
			//hiddenText.p2WinsTurnOn ();
		}
	}
	//give damage to player 02
	public void P2TakeDamage(int damageToGive)
	{
		//subtracts damage from health
		P2HealthCounter -= damageToGive;

		//sets negative health to zero
		if (P2HealthCounter <= 0)                              
		{
			P2HealthCounter = 0;
			//player 01 win screen
			//hiddenText.p1WinsTurnOn ();
		}
	}
	
}