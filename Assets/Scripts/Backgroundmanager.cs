using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Backgroundmanager : MonoBehaviour
{
    public static Backgroundmanager background { get; set; }
    [SerializeField] public Text stepsText;
    [SerializeField] public Text totalStepsText;
    [SerializeField] public Text syncedDateText;
    public int curStep;

    private AndroidJavaClass unityClass;
    private AndroidJavaObject unityActivity;
    private AndroidJavaClass customClass;
    private const string PlayerPrefsTotalSteps = "totalSteps";
    private const string PackageName = "com.kdg.toast.plugin.Bridge";
    private const string UnityDefaultJavaClassName = "com.unity3d.player.UnityPlayer";
    private const string CustomClassReceiveActivityInstanceMethod = "ReceiveActivityInstance";
    private const string CustomClassStartServiceMethod = "StartService";
    private const string CustomClassStopServiceMethod = "StopService";
    private const string CustomClassGetCurrentStepsMethod = "GetCurrentSteps";
    private const string CustomClassSyncDataMethod = "SyncData";

    public int prevStep;
    DateTime today;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (background == null)
            background = this;
        else if (background != this)
            Destroy(gameObject);
        SendActivityReference(PackageName);
        GetCurrentSteps();
    }

    private void Start()
    {
        CancelInvoke("GetCurrentSteps");
        StartService();
        InvokeRepeating("GetCurrentSteps", 1.0f, 1.0f);
    }


    private void SendActivityReference(string packageName)
    {
        unityClass = new AndroidJavaClass(UnityDefaultJavaClassName);
        unityActivity = unityClass.GetStatic<AndroidJavaObject>("currentActivity");
        customClass = new AndroidJavaClass(packageName);
        customClass.CallStatic(CustomClassReceiveActivityInstanceMethod, unityActivity);
    }

    public void StartService()
    {
        customClass.CallStatic(CustomClassStartServiceMethod);
        today = DateTime.Now.Date;
        GetCurrentSteps();
    }

    public void StopService()
    {
        customClass.CallStatic(CustomClassStopServiceMethod);
    }

    public void GetCurrentSteps()
    {
        int stepsCount = customClass.CallStatic<int>(CustomClassGetCurrentStepsMethod);
        if(today.Date != DateTime.Now.Date)
        {
            prevStep = curStep;
            curStep = 0;
        }
        curStep = stepsCount;
    }

    public void SyncData()
    {
        var data = customClass.CallStatic<string>(CustomClassSyncDataMethod);

        var parsedData = data.Split('#');
        var dateOfSync = parsedData[0] + " - " + parsedData[1];
        syncedDateText.text = dateOfSync;
        var receivedSteps = int.Parse(parsedData[2]);
        var prefsSteps = PlayerPrefs.GetInt(PlayerPrefsTotalSteps, 0);
        var prefsStepsToSave = prefsSteps + receivedSteps;
        PlayerPrefs.SetInt(PlayerPrefsTotalSteps, prefsStepsToSave);
        totalStepsText.text = prefsStepsToSave.ToString();

        GetCurrentSteps();
    }
}
