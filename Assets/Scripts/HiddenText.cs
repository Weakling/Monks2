using UnityEngine;
using System.Collections;
//using UnityEngine.UI;

public class HiddenText : MonoBehaviour {

	public GameObject roundEndCanvas;
	public GameObject p1WinsCanvas;
	public GameObject p2WinsCanvas;

	// Use this for initialization
	void Start () 
	{
		roundEndCanvas.SetActive (false);
		p1WinsCanvas.SetActive (false);
		p2WinsCanvas.SetActive (false);
	}
	
	public void roundEndTurnOn()
	{
		roundEndCanvas.SetActive (true);

	}

	public void roundEndTurnOff()
	{
		roundEndCanvas.SetActive (false);

	}

	public void p1WinsTurnOn()
	{
		p1WinsCanvas.SetActive (true);
	}

	public void p1WinsTurnOff()
	{
		p1WinsCanvas.SetActive (false);
	}

	public void p2WinsTurnOn()
	{
		p2WinsCanvas.SetActive (true);
	}
	public void p2WinsTurnOff()
	{
		p2WinsCanvas.SetActive (false);
	}

}
