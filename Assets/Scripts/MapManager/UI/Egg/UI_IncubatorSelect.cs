using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_IncubatorSelect : MonoBehaviour
{
    public Button btn;
    public int incuNum = 0;
    public Text bornTimeText;
    GameObject egg;
    TimeSpan timeCal;
    int leftTime = 100;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == 1)
        {
            bornTimeText.text = "대기중";
            leftTime = 100;
        }
        if (transform.childCount >= 2)
        {
            egg = transform.GetChild(1).gameObject;
            timeCal = DateManager.dateManager.now - egg.GetComponent<EggInfo>().startBornTime;
            leftTime = (egg.GetComponent<EggInfo>().bornTime - timeCal.Minutes - (timeCal.Hours * 60) - (timeCal.Days * 1440));
            bornTimeText.text = "부화중\n" + (leftTime / 60).ToString() + " : " + (leftTime % 60).ToString("00");
        }
        if(leftTime <= 0)
        {
            leftTime = 0;
            bornTimeText.text = "부화 완료!";
        }
    }

    public void OnClick()
    {
        if(DataManager.dataManager.eggCode.Count == DataManager.dataManager.eggBag && leftTime == 0)
        {
            SoundManager.soundManager.DeniedSound();
            gameObject.transform.parent.GetChild(5).gameObject.SetActive(true);
            gameObject.transform.parent.GetChild(5).gameObject.GetComponent<UI_EggErrorMessage>().SlimeBagMessage();
        }
        else if (leftTime == 0)
        {
            SoundManager.soundManager.CreateSound();
            EggManager.eggManager.SlimeBorn(egg);
        }
        else if (transform.childCount >= 2)
            return;
        else if (transform.childCount == 1)
        {
            SoundManager.soundManager.ItemSound();
            EggManager.eggManager.OpenEggList();
            EggManager.eggManager.targetIncu = gameObject;
            EggManager.eggManager.eggListUp();
        }

    }
}
