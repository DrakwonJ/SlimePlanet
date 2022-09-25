using PedometerU;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo playerInfo { get; set; }


    public int _spawnTime;
    public bool spawnOk = false;
    public int _spawnWalk;
    public int _currWalk;
    public int _startWalk;
    public GameObject SpawnWindow;
    public GameObject fullSlime;
    //private Pedometer pedometer;


    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (playerInfo == null)
            playerInfo = this;
        else if (playerInfo != this)
            Destroy(gameObject);
    }

    void Start()
    {
        /*
        if (!Permission.HasUserAuthorizedPermission("android.permission.ACTIVITY_RECOGNITION"))
        {
            Permission.RequestUserPermission("android.permission.ACTIVITY_RECOGNITION");
        }
        else
        {
            Debug.Log("Permission OK");
        }
        pedometer = new Pedometer(OnStep);
        OnStep(0, 0);
        */
        // Reset UI

        InvokeRepeating("spawnCheck", 3.0f, 1.0f);


        _startWalk = 0;
        _spawnWalk = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (SpawnWindow == null && SceneManager.GetActiveScene().name == "MainScene")
        {
            SpawnWindow = GameObject.Find("CatchSlime");
            if(SpawnWindow != null)
                SpawnWindow.SetActive(false);
        }

    }
    /*
    private void OnStep(int steps, double distance)
    {
        // Display the values // Distance in feet
        _currWalk = steps;
    }

    private void OnDisable()
    {
        //Release the pedometer
        pedometer.Dispose();
        pedometer = null;
    }
    */
    
    public void spawnCheck()
    {
        if (SceneManager.GetActiveScene().name == "MainScene" && DataManager.dataManager.curChance > 0 && DataManager.dataManager.slimeBag > DataManager.dataManager.slimeCode.Count)
        {
            int num = Random.Range(0, DataManager.dataManager.spawnTime + 1);
            if (num < _currWalk - _spawnWalk)
            {
                if (DataManager.dataManager.slimeBag == DataManager.dataManager.slimeCode.Count)
                {
                    fullSlime.SetActive(true);
                }
                else
                {
                    SpawnWindow.gameObject.SetActive(true);
                }
                _spawnWalk = _currWalk;
            }
        }
    }
}
