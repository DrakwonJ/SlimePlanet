using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EggManager : MonoBehaviour
{
    public static EggManager eggManager { get; set; }
    public List<GameObject> eggPrefab;
    public int incubator = 0;
    public GameObject incubatorImg;
    public GameObject incubatorLayout;
    public GameObject incuWindow;
    public bool ready=false;

    public GameObject targetIncu;
    public GameObject targetEgg;

    public GameObject eggListWindow;
    public bool eggListOn = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (eggManager == null)
            eggManager = this;
        else if (eggManager != this)
            Destroy(gameObject);
    }

    public List<GameObject> eggList;
    public List<GameObject> incubatorList;
    public GameObject eggLayout;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        incubator = DataManager.dataManager.incubator;
        SwitchCodetoEgg();
        ready = true;
        incuWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (incubator != DataManager.dataManager.incubator)
            incubator = DataManager.dataManager.incubator;
        if (eggListWindow.activeSelf == false)
            eggListOn = false;
    }

    public void IncubatorAdd()
    {
        incubator += 1;
        DataManager.dataManager.IncreaseData("incubator");
        DataManager.dataManager.SubmitData();
        GameObject obj = Instantiate(incubatorImg, incubatorLayout.transform);
        obj.transform.SetSiblingIndex(incubator-1);
    }

    public void OpenEggList()
    {
        eggListWindow.SetActive(true);
        RectTransform rect = eggListWindow.GetComponent<RectTransform>();
        rect.sizeDelta = canvas.GetComponent<RectTransform>().sizeDelta;
    }

    public void SwitchCodetoEgg()
    {
        incuWindow.SetActive(true);
        int eggPool, parentPool1, parentPool2, potential, borntime, incubatorNum, listNum;
        long startBornTimelong;
        DateTime startBornTime;
        for(int i = 0; i < DataManager.dataManager.eggCode.Count; i++)
        {
            eggPool = Int32.Parse(DataManager.dataManager.eggCode[i].Substring(0, 2));
            parentPool1 = Int32.Parse(DataManager.dataManager.eggCode[i].Substring(2, 2));
            parentPool2 = Int32.Parse(DataManager.dataManager.eggCode[i].Substring(4, 2));
            potential = Int32.Parse(DataManager.dataManager.eggCode[i].Substring(6, 3));
            borntime = Int32.Parse(DataManager.dataManager.eggCode[i].Substring(9, 4));
            startBornTimelong = long.Parse(DataManager.dataManager.eggCode[i].Substring(13, 14));
            incubatorNum = Int32.Parse(DataManager.dataManager.eggCode[i].Substring(27, 2));
            listNum = Int32.Parse(DataManager.dataManager.eggCode[i].Substring(29, 1));

            if (DateTime.TryParseExact(startBornTimelong.ToString(), "yyyyMMddHHmmss", 
                CultureInfo.InvariantCulture, DateTimeStyles.None, out startBornTime)) ;


            GameObject spawnEgg = Instantiate(eggPrefab[eggPool], new Vector3(0,0,0), eggPrefab[eggPool].transform.rotation);
            spawnEgg.transform.localScale = new Vector3(1, 1, 1);
            spawnEgg.GetComponent<EggInfo>().eggCode = DataManager.dataManager.eggCode[i];
            spawnEgg.GetComponent<EggInfo>().pool = (Define.EggPool)eggPool;
            spawnEgg.GetComponent<EggInfo>().parentPool1 = parentPool1;
            spawnEgg.GetComponent<EggInfo>().parentPool2 = parentPool2;
            spawnEgg.GetComponent<EggInfo>().potential = potential;
            spawnEgg.GetComponent<EggInfo>().bornTime = borntime;
            spawnEgg.GetComponent<EggInfo>().startBornTime = startBornTime;
            spawnEgg.GetComponent<EggInfo>().incubatorNum = incubatorNum;
            spawnEgg.GetComponent<EggInfo>().eggListNum = listNum;
            if (incubatorNum == 0)
                eggList.Add(spawnEgg);
            else
                incubatorList.Add(spawnEgg);
            spawnEgg.transform.parent = incubatorLayout.transform;
        }
        incuWindow.SetActive(false);
        
        ready = true;
    }

    public GameObject dragCon;
    public GameObject sort;
    public void eggListUp()
    {
        eggListOn = true;
        for(int i = 0; i < eggList.Count; i++)
        {
            eggList[i].transform.SetParent(eggLayout.transform);
            eggList[i].transform.localScale = new Vector3(400, 400, 400);
            eggList[i].GetComponent<EggInfo>().infoTxt.SetActive(false);
            eggList[i].GetComponent<EggInfo>().selectBtn.SetActive(false);
        }
        dragCon.GetComponent<DragController>().instaniateOver = true;
    }

    public void PlaceEggIncu()
    {
        targetEgg.GetComponent<EggInfo>().incubatorNum = targetIncu.GetComponent<UI_IncubatorSelect>().incuNum;
        targetEgg.GetComponent<EggInfo>().startBornTime = DateManager.dateManager.now;
        string prevCode = targetEgg.GetComponent<EggInfo>().eggCode;
        targetEgg.GetComponent<EggInfo>().ReplaceCode();
        incubatorList.Add(targetEgg);
        eggList.Remove(targetEgg);
        DataManager.dataManager.ReplaceEggCode(targetEgg.GetComponent<EggInfo>().eggListNum,prevCode,targetEgg.GetComponent<EggInfo>().eggCode);
        DataManager.dataManager.SubmitData("EggList");
        targetEgg.transform.SetParent(targetIncu.transform);
        targetEgg.transform.localPosition = new Vector3(0, -150, 0);
        eggListOn = false;
        dragCon.GetComponent<DragController>().instaniateOver = true;
    }


    public GameObject slimeBorn;

    public void SlimeBorn(GameObject egg)
    {
        slimeBorn.SetActive(true);
        GameObject BornSlime = CreateSlimeManager.createSlime.CreateSlimeByEgg(egg);
        BornSlime.transform.SetParent(slimeBorn.transform);
        BornSlime.transform.localScale = new Vector3(500, 500, 500);
        BornSlime.transform.localPosition = new Vector3(0, -100, 0);
        BornSlime.GetComponent<SlimeInfo>().UI_ON();
        incubatorList.Remove(egg);
        DataManager.dataManager.AddSlimeCode(BornSlime.GetComponent<SlimeInfo>().slimeListNum, BornSlime.GetComponent<SlimeInfo>().slimeCode);
        DataManager.dataManager.SubmitData("SlimeList");
        DataManager.dataManager.RemoveEggCode(egg.GetComponent<EggInfo>().eggListNum,egg.GetComponent<EggInfo>().eggCode);
        DataManager.dataManager.SubmitData("EggList");
        DataManager.dataManager.IncreaseData("totalBorn");
        DataManager.dataManager.SubmitData();
        if (DataManager.dataManager.daily_born < 1)
        {
            DataManager.dataManager.IncreaseDailyData("bornTime");
            DataManager.dataManager.SubmitData("DailyQuest");
        }
        if (DataManager.dataManager.weekly_born < 5)
        {
            DataManager.dataManager.IncreaseWeeklyData("bornTime");
            DataManager.dataManager.SubmitData("WeeklyQuest");
        }
        Destroy(egg);
    }

}
