using UnityEngine;
using System.Collections;

public class OptionsManager : MonoBehaviour {

    public Transform Elder01Start;
    public Transform Elder02Start;
    public Transform ElderSoloStart;

    [SerializeField] private GameObject elderMonk01;
    [SerializeField] private GameObject elderMonk02;

    public static int elderCount;
    public static int trainHazard;
    public static int spikeHazard;
    
    
    void Awake ()
    {
        // find playerprefs info
        elderCount = PlayerPrefs.GetInt("ElderCount", 2);   // gets number of elders
        trainHazard = PlayerPrefs.GetInt("TrainHazard", 1); // gets train true/false
        spikeHazard = PlayerPrefs.GetInt("SpikeHazard", 1); // gets spikes true/false

        // spawn one elder
        if (elderCount == 1)
        {
            elderMonk01.transform.position = ElderSoloStart.transform.position; // elder monk spawns middle
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
