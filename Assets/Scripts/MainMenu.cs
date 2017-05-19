using UnityEngine;
using UnityEditor.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	//canvases
	public GameObject mainMenuCanvas;
	public GameObject vsMenuCanvas;

    // gameobjects
    public GameObject elderGO, anvilGO, trainGO, anvilPrefab, trainPrefab;

    // scripts
    private Anvil anvilScript;
    private Train trainScript;
    private ElderLeft elderScript;

    // positions
    public Transform anvilPosition, anvilSpawn, trainPosition, trainSpawn;

    // buttons
    [SerializeField] private Toggle onTrain;
    [SerializeField] private Toggle offTrain;
    public Toggle oneElders, twoElders, onAnvil, offAnvil;

    // ctrs
    private int onClickTrain, onClickAnvil, onClickElders;
    
    // level
	public string level01;

    void Awake()
    {
        // set counters
        onClickAnvil = 1;
        onClickTrain = 1;
        onClickElders = 1;

        // get scripts
        anvilScript = anvilGO.GetComponent<Anvil>();
        trainScript = trainGO.GetComponent<Train>();
        elderScript = elderGO.GetComponent<ElderLeft>();
    }

	void Start () 
	{
		vsMenuCanvas.SetActive (false);
        SetDefault();
        twoElders.interactable = false;
        onAnvil.interactable = false;
        onTrain.interactable = false;
	}
	
    // quit
	public void Quit()
	{
		Application.Quit ();
	}

	// vs start
	public void vsModeStart()
	{
		//Application.LoadLevel (level01);
        EditorSceneManager.LoadScene(1);
	}

    // click 2 elders
    public void elders02()
    {
        // anvil clicked on
        if (twoElders.isOn == true)
        {
            twoElders.interactable = false;   // can't click now
            oneElders.isOn = false;          // tick off removed
            oneElders.interactable = true;   // can click other
            elderScript.Rise();
        }
    }

    // click one elder
    public void elders01()
	{
        // anvil clicked off
        if (oneElders.isOn == true)
        {
            oneElders.interactable = false;  // can't click now
            twoElders.isOn = false;           // tick on removed
            twoElders.interactable = true;    // can click other
            elderScript.Sink();
        }
    }

    public void OnAnvil()
    {
        // anvil clicked on
        if (onAnvil.isOn == true)
        {
            onAnvil.interactable = false;   // can't click now
            offAnvil.isOn = false;          // tick off removed
            offAnvil.interactable = true;   // can click other
            SpawnAnvil();
        }
    }

    public void OffAnvil()
    {
        // anvil clicked off
        if (offAnvil.isOn == true)
        {
            offAnvil.interactable = false;  // can't click now
            onAnvil.isOn = false;           // tick on removed
            onAnvil.interactable = true;    // can click other
            anvilScript.Leave();
        }
    }

    public void OnTrain()
    {
        // train clicked on
        if (onTrain.isOn == true)
        {
            onTrain.interactable = false;   // can't click now
            offTrain.isOn = false;          // tick off removed
            offTrain.interactable = true;   // can click other
            SpawnTrain();
        }
    }

    public void OffTrain()
    {
        // train clicked off
        if (offTrain.isOn == true)
        {
            offTrain.interactable = false;  // can't click now
            onTrain.isOn = false;           // tick on removed
            onTrain.interactable = true;    // can click other
            trainScript.Leave();
        }
    }

    private void SetDefault()
    {
        onAnvil.isOn = true;
        offAnvil.isOn = false;
        onTrain.isOn = true;
        offTrain.isOn = false;
    }

    private void SpawnAnvil()
    {
        GameObject anvil = Instantiate(anvilPrefab, anvilSpawn.position, Quaternion.identity);
        anvilScript = anvil.GetComponent<Anvil>();
        anvilScript.spawnDestination = anvilPosition;
        anvilScript.Spawn();
    }

    private void SpawnTrain()
    {
        GameObject train = Instantiate(trainPrefab, trainSpawn.position, Quaternion.identity);
        trainScript = train.GetComponent<Train>();
        trainScript.spawnDestination = trainPosition;
        trainScript.Spawn();
    }
}
