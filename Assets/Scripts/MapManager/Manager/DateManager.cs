using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateManager : MonoBehaviour
{
    public static DateManager dateManager { get; set; }
    public DateTime now;
    public bool isDelay = false;
    public float delayTime = 60.0f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (dateManager == null)
            dateManager = this;
        else if (dateManager != this)
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        now = DateTime.Now;
        if (BackEnd.Backend.UserNickName == "")
            return;
        if(isDelay == false)
        {
            isDelay = true;
            StartCoroutine(Save());
        }
    }

    IEnumerator Save()
    {
        yield return new WaitForSeconds(delayTime);
        if (DataManager.dataManager.endTime.Date != now.Date)
        {
            Debug.Log(now.Date);
            Debug.Log(DataManager.dataManager.endTime.Date);
            DataManager.dataManager.ResetDateChance();
            DataManager.dataManager.UpdateDate();
            DataManager.dataManager.SubmitData();
        }
        isDelay = false;
    }
}
