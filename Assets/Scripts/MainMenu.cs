using UnityEngine;
using UnityEditor.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	//canvases
	public GameObject mainMenuCanvas;
	public GameObject vsMenuCanvas;
    [SerializeField] private Toggle onTrain;
    [SerializeField] private Toggle offTrain;
    

	public string level01;
	//public string mainMenu;
	//public string vsMenu;

	// Use this for initialization
	void Start () 
	{
		vsMenuCanvas.SetActive (false);
        SetDefault();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//main menu
	public void goVsMenu()
	{
		//hide other canvas
		mainMenuCanvas.SetActive (false);
		//show vs menu 
		vsMenuCanvas.SetActive (true);
	}

	public void Quit()
	{
		Application.Quit ();
	}


	//vs settings
	public void vsModeStart()
	{
		//Application.LoadLevel (level01);
        EditorSceneManager.LoadScene(1);
	}

	public void elders01()
	{

	}

	public void elders02()
	{

	}

    public void OnTrain()
    {
        if(onTrain.isOn == false)
        {
            onTrain.isOn = true;    // tick on set
            offTrain.isOn = false;  // tick off removed
        }
        
    }

    public void OffTrain()
    {
        //offTrain.isOn = true;   // tick off set
        //onTrain.isOn = false;   // tick on removed
    }

	public void goBackMenu()
	{
		//hide other canvas
		vsMenuCanvas.SetActive (false);
		//show main menu
		mainMenuCanvas.SetActive (true);
	}

    private void SetDefault()
    {
        onTrain.isOn = true;
        offTrain.isOn = false;
        
    }
}
