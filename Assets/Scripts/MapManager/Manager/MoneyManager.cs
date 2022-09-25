using BackEnd;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager moneyManager { get; set; }
    public int sellMoney;
    public DragController dragCon;
    public List<GameObject> SellSlimeList = new List<GameObject>();
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (moneyManager == null)
            moneyManager = this;
        else if (moneyManager != this)
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        sellMoney = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SellSlime()
    {
        int prevSlimeCount = DataManager.dataManager.slimeCode.Count;
        int sellSlimeCount = SellSlimeList.Count;
        for(int i = 0; i < SellSlimeList.Count; i++)
        {
            DataManager.dataManager.RemoveSlimeCode(SellSlimeList[i].transform.GetComponent<SlimeInfo>().slimeListNum,
                SellSlimeList[i].transform.GetComponent<SlimeInfo>().slimeCode);
            Destroy(SellSlimeList[i]);
        }
        DataManager.dataManager.SubmitData("SlimeList");
        SellSlimeList.Clear();
        dragCon.SetDragLimit(prevSlimeCount - sellSlimeCount);
        DataManager.dataManager.IncreaseData("money", sellMoney);
        DataManager.dataManager.SubmitData("PlayerCurrency");
        if(DataManager.dataManager.daily_earnMoney < 500)
        {
            DataManager.dataManager.IncreaseDailyData("earnMoney", sellMoney);
            DataManager.dataManager.SubmitData("DailyQuest");
        }
        if(DataManager.dataManager.weekly_earnMoney < 2500)
        {
            DataManager.dataManager.IncreaseWeeklyData("earnMoney", sellMoney);
            DataManager.dataManager.SubmitData("WeeklyQuest");
        }
        sellMoney = 0;
    }

    public void AddSellSlime(GameObject target)
    {
        SellSlimeList.Add(target);
        sellMoney += target.GetComponent<SlimeInfo>().power;
    }

    public void SubtractSellSlime(GameObject target)
    {
        SellSlimeList.Remove(target);
        sellMoney -= target.GetComponent<SlimeInfo>().power;
    }
}
