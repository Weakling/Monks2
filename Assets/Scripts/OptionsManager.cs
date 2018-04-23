using UnityEngine;
using System.Collections;

public class OptionsManager : MonoBehaviour {

    public Transform Elder01Start;
    public Transform Elder02Start;
    public Transform ElderSoloStart;
    public Transform trainStartLeft, trainStartRight;
    public Transform anvilStart;

    [SerializeField] private GameObject elderMonk01;
    [SerializeField] private GameObject elderMonk02;
    [SerializeField] private GameObject elderMonkSolo;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject trainGO;
    [SerializeField] private GameObject anvilGO;

    private GameObject justMadeTrain, justMadeAnvil; 

    private TrainCombat currentTrain;
    private AnvilCombat currentAnvil;

    public static int elderCount;
    public static int anvilHazard;
    public static int trainHazard;

    private bool trainClockGoing, anvilClockGoing;
    public bool trainCanSet, anvilCanSet;

    private float trainSpeed;
    public float trainSpeedLow, trainSpeedHigh;
    public float trainTimeLow, trainTimeHigh;
    public float trainTimer;
    public int trainLeftRight;

    private float anvilSpeed;
    public float anvilSpeedLow, anvilSpeedHigh;
    public float anvilTimeLow, anvilTimeHigh;
    public float anvilTimer;
    public int anvilLeftRight;

    
    void Awake ()
    {
        // find playerprefs info
        elderCount = PlayerPrefs.GetInt("ElderCount", 2);   // gets number of elders
        anvilHazard = PlayerPrefs.GetInt("AnvilHazard", 1); // gets spikes true/false
        trainHazard = PlayerPrefs.GetInt("TrainHazard", 1); // gets train true/false

        // DEBUG
        print(elderCount);
        print(anvilHazard);
        print(trainHazard);

        // spawn one elder
        if (elderCount == 1)
        {
            Instantiate(elderMonkSolo, ElderSoloStart.transform.position, Quaternion.identity); // single elder monk spawns middle
        }
        // spawn two elders
        else if (elderCount == 2)
        {
            Instantiate(elderMonk01, Elder01Start.transform.position, Quaternion.identity);
            Instantiate(elderMonk02, Elder02Start.transform.position, Quaternion.identity);
        }
    }

    private void Start()
    {
        trainCanSet = true;
        anvilCanSet = true;
    }

    private void Update()
    {
        if(trainHazard == 1)
        {
            if (!trainClockGoing)
            {
                if (trainCanSet)
                {
                    TrainSet();
                }
            }
            else
            {
                trainTimer -= Time.deltaTime;
                if (trainTimer <= 0)
                {
                    TrainSpawn();
                }
            }
        }

        if(anvilHazard == 1)
        {
            if (!anvilClockGoing)
            {
                if (anvilCanSet)
                {
                    AnvilSet();
                }
            }
            else
            {
                anvilTimer -= Time.deltaTime;
                if (anvilTimer <= 0)
                {
                    AnvilSpawn();
                }
            }
        }
        
    }




    public void TrainSet()
    {
        trainTimer = Random.Range(trainTimeLow, trainTimeHigh);
        trainSpeed = Random.Range(trainSpeedLow, trainSpeedHigh);
        trainLeftRight = Random.Range(0, 2);
        trainClockGoing = true;
        trainCanSet = false;
    }

    public void TrainSpawn()
    {
        if (trainLeftRight == 0)
        {
            justMadeTrain = Instantiate(trainGO, trainStartLeft.transform.position, Quaternion.identity);
        }
        else if (trainLeftRight == 1)
        {
            justMadeTrain = Instantiate(trainGO, trainStartRight.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("your train's messed up");
        }

        trainClockGoing = false;
        currentTrain = justMadeTrain.GetComponent<TrainCombat>();
        currentTrain.myOptionsManager = this.transform.GetComponent<OptionsManager>();
        currentTrain.speed = trainSpeed;
        currentTrain.leftRight = trainLeftRight;
    }


    public void AnvilSet()
    {
        anvilTimer = Random.Range(anvilTimeLow, anvilTimeHigh);
        anvilSpeed = Random.Range(anvilTimeLow, anvilTimeHigh);
        anvilLeftRight = Random.Range(0, 2);
        anvilClockGoing = true;
        anvilCanSet = false;
    }

    public void AnvilSpawn()
    {
        if (anvilLeftRight == 0)
        {
            anvilStart.transform.position = new Vector2(player1.transform.position.x, anvilStart.transform.position.y);
            justMadeAnvil = Instantiate(anvilGO, anvilStart.transform.position, Quaternion.identity);
        }
        else if (anvilLeftRight == 1)
        {
            anvilStart.transform.position = new Vector2(player2.transform.position.x, anvilStart.transform.position.y);
            justMadeAnvil = Instantiate(anvilGO, anvilStart.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("your anvil's messed up");
        }

        anvilClockGoing = false;
        currentAnvil = justMadeAnvil.GetComponent<AnvilCombat>();
        currentAnvil.myOptionsManager = this.transform.GetComponent<OptionsManager>();
        currentAnvil.speed = trainSpeed;
    }
}
