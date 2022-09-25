using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Define;
using BackEnd;

public class MatingManager : MonoBehaviour
{
    public static MatingManager matingManager { get; set; }
    public List<GameObject> eggType;
    public GameObject resultWindow;
    public int eggRand;
    public int potential;
    public GameObject egg;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (matingManager == null)
            matingManager = this;
        else if (matingManager != this)
            Destroy(gameObject);
    }
    public bool matingState = false;

    public GameObject targetSlot1;
    public GameObject targetSlot2;
    public GameObject target;
    public GameObject targetSlime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SlimeMatingSelect()
    {
        GameObject obj = Instantiate(targetSlime, target.transform);
        obj.transform.localPosition = new Vector3(0, -200, 0);
        obj.transform.localScale = new Vector3(600, 600, 600);
        obj.transform.rotation = Quaternion.Euler(180, 0, 180);
        obj.GetComponent<SlimeInfo>().UI1.SetActive(false);
        obj.GetComponent<SlimeInfo>().UI2.SetActive(false);
        obj.GetComponent<SlimeInfo>().UI3.SetActive(false);

        Image img = targetSlime.GetComponent<SlimeInfo>().UI3.GetComponent<Image>();
        Color color = img.GetComponent<Image>().color;
        color.a = 0.0f;
        img.color = color;
    }

    public GameObject fullMessage;

    public void StartMating()
    {
        if (targetSlot1.transform.childCount == 0 || targetSlot2.transform.childCount == 0)
            return;
        else if (DataManager.dataManager.eggBag == EggManager.eggManager.eggList.Count)
        {
            SoundManager.soundManager.DeniedSound();
            fullMessage.SetActive(true);
            fullMessage.GetComponent<UI_MatingError>().FullEggList();
        }
        else if(targetSlot1.transform.GetChild(0).gameObject.GetComponent<SlimeInfo>().slimeCode ==
            targetSlot2.transform.GetChild(0).gameObject.GetComponent<SlimeInfo>().slimeCode)
        {
            SoundManager.soundManager.DeniedSound();
            fullMessage.SetActive(true);
            fullMessage.GetComponent<UI_MatingError>().SameSlimeChoose();
        }
        else
        {
            SoundManager.soundManager.CreateSound();
            resultWindow.SetActive(true);
            EggManager.eggManager.eggListOn = false;
            potential = targetSlot2.transform.GetChild(0).gameObject.GetComponent<SlimeInfo>().power +
                targetSlot1.transform.GetChild(0).gameObject.GetComponent<SlimeInfo>().power;
            potential /= 2;
            potential += Random.Range(-5, 6);
            potential += DataManager.dataManager.eggPotential;
            eggRand = Random.Range(0, 1);
            egg = Instantiate(eggType[eggRand], resultWindow.transform.GetChild(2));
            egg.GetComponent<EggInfo>().CreateEggCode();
            egg.transform.localPosition = new Vector3(0, -200, 0);
            egg.transform.localScale = new Vector3(600, 600, 600);
            EggManager.eggManager.eggList.Add(egg);
            DataManager.dataManager.DecreaseData("curMating");
            DataManager.dataManager.IncreaseData("totlaMating");
            DataManager.dataManager.SubmitData();
            DataManager.dataManager.AddEggCode(egg.GetComponent<EggInfo>().eggListNum,egg.GetComponent<EggInfo>().eggCode);
            DataManager.dataManager.SubmitData("EggList");
            if (DataManager.dataManager.daily_mate < 2)
            {
                DataManager.dataManager.IncreaseDailyData("matingTime");
                DataManager.dataManager.SubmitData("DailyQuest");
            }
            if (DataManager.dataManager.weekly_mate < 10)
            {
                DataManager.dataManager.IncreaseWeeklyData("matingTime");
                DataManager.dataManager.SubmitData("WeeklyQuest");
            }
        }
    }
}
