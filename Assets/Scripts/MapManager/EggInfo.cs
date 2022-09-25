using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Define;

public class EggInfo : MonoBehaviour
{
    public int potential;
    public EggPool pool;
    public string eggCode;
    public int parentPool1, parentPool2;
    public int bornTime;
    public DateTime startBornTime;
    public int incubatorNum;
    public int eggListNum;

    public GameObject infoTxt, selectBtn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (EggManager.eggManager.eggListOn == false)
        {
            infoTxt.SetActive(false);
            selectBtn.SetActive(false);
        }
        else
        {
            infoTxt.SetActive(true);
            selectBtn.SetActive(true);
        }
    }

    public void CreateEggCode()
    {

        parentPool1 = (int)GameObject.Find("target1").transform.GetChild(0).gameObject.GetComponent<SlimeInfo>().pool;
        parentPool2 = (int)GameObject.Find("target2").transform.GetChild(0).gameObject.GetComponent<SlimeInfo>().pool;
        potential = MatingManager.matingManager.potential;

        //eggpool + parentpool + parentpool + potential + borntime + curbornTime + incubatorNum
        int typeNum = MatingManager.matingManager.eggRand;
        pool = (EggPool)typeNum;
        int val = (int)pool;
        if (val < 10)
            eggCode = "0" + val.ToString();
        else
            eggCode = val.ToString();
        if (parentPool1 < 10)
            eggCode += "0" + parentPool1.ToString();
        else
            eggCode += parentPool1.ToString();
        if (parentPool2 < 10)
            eggCode += "0" + parentPool2.ToString();
        else
            eggCode += parentPool2.ToString();
        eggCode += potential.ToString("000");
        bornTime = (potential / 10)*60;
        eggCode += bornTime.ToString("0000");
        eggCode += "00000000000000";
        eggCode += "00"; // incubatornum
        eggListNum = CheckEggList();
        eggCode += eggListNum;
    }

    public void ReplaceCode()
    {
        int val = (int)pool;
        if (val < 10)
            eggCode = "0" + val.ToString();
        else
            eggCode = val.ToString();
        if (parentPool1 < 10)
            eggCode += "0" + parentPool1.ToString();
        else
            eggCode += parentPool1.ToString();
        if (parentPool2 < 10)
            eggCode += "0" + parentPool2.ToString();
        else
            eggCode += parentPool2.ToString();
        eggCode += potential.ToString("000");
        bornTime = (potential / 10) * 60;
        eggCode += bornTime.ToString("0000");
        eggCode += startBornTime.ToString("yyyyMMddHHmmss");
        eggCode += incubatorNum.ToString("00"); // incubatornum
        eggCode += eggListNum.ToString();
    }


    public int CheckEggList()
    {
        if (DataManager.dataManager.eggNum0 < 10)
            return 0;
        else if (DataManager.dataManager.eggNum1 < 10)
            return 1;                    
        else if (DataManager.dataManager.eggNum2 < 10)
            return 2;                 
        else if (DataManager.dataManager.eggNum3 < 10)
            return 3;                 
        else if (DataManager.dataManager.eggNum4 < 10)
            return 4;               
        else if (DataManager.dataManager.eggNum5 < 10)
            return 5;                
        else if (DataManager.dataManager.eggNum6 < 10)
            return 6;                 
        else if (DataManager.dataManager.eggNum7 < 10)
            return 7;                
        else if (DataManager.dataManager.eggNum8 < 10)
            return 8;
        else
            return 9;
    }
}
