using UnityEngine;
using System.Collections;

public class OptionsManager : MonoBehaviour {

    public Transform Elder01Start;
    public Transform Elder02Start;
    public Transform ElderSoloStart;

    [SerializeField] private GameObject elderMonk01;
    [SerializeField] private GameObject elderMonk02;
    [SerializeField] private GameObject elderMonkSolo;

    public static int elderCount;
    public static int anvilHazard;
    public static int trainHazard;  
    
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
            elderMonk02.SetActive(true);                                        // set elder02 active
            elderMonk01.transform.position = Elder01Start.transform.position;   // elder01 spawns left
            elderMonk02.transform.position = Elder02Start.transform.position;   // elder02 spawns right
        }
    }
}
