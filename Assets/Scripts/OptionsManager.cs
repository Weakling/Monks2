using UnityEngine;
using System.Collections;

public class OptionsManager : MonoBehaviour {

    public Transform Elder01Start;
    public Transform Elder02Start;
    public Transform ElderSoloStart;
    public Transform trainStartLeft, trainStartRight;
    public Transform anvilStartLeft, anvilStartRight;

    [SerializeField] private GameObject elderMonk01;
    [SerializeField] private GameObject elderMonk02;
    [SerializeField] private GameObject elderMonkSolo;
    [SerializeField] private GameObject trainGO;
    [SerializeField] private GameObject anvilGO;

    private GameObject justMade; 

    private Train currentTrain;
    private Anvil currentAnvil;

    public static int elderCount;
    public static int anvilHazard;
    public static int trainHazard;

    private bool trainClockGoing, anvilClockGoing;

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

    private void Update()
    {
        if(!trainClockGoing)
        {
            TrainSet();
        }
        else
        {
            trainTimer -= Time.deltaTime;
            if(trainTimer <= 0)
            {
                if(trainLeftRight == 0)
                {
                    justMade = Instantiate(trainGO, trainStartLeft.transform.position, Quaternion.identity);
                }
                else if (trainLeftRight == 1)
                {
                    justMade = Instantiate(trainGO, trainStartRight.transform.position, Quaternion.identity);
                }
                else
                {
                    Debug.LogError("your train's messed up");
                }

                currentTrain = justMade.GetComponent<Train>();
                currentTrain.myOptionsManager = this.transform.GetComponent<OptionsManager>();
                currentTrain.speed = trainSpeed;

            }
        }

        if(!anvilClockGoing)
        {
            AnvilSet();
        }
    }




    public void TrainSet()
    {
        trainTimer = Random.Range(trainTimeLow, trainTimeHigh);
        trainSpeed = Random.Range(trainSpeedLow, trainSpeedHigh);
        trainLeftRight = Random.Range(0, 2);
        trainClockGoing = true;
    }


    public void AnvilSet()
    {
        anvilTimer = Random.Range(anvilTimeLow, anvilTimeHigh);
    }
}
