using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalQuest : MonoBehaviour
{
    public GameObject daily;
    public GameObject weekly;
    public GameObject achieve;
    public Text rewardTxt;
    public Text rewardNum;
    public Button rewardBtn;
    // Start is called before the first frame update
    void Start()
    {
        rewardBtn = gameObject.GetComponent<Button>();
        rewardBtn.onClick.AddListener(GetReward);
    }

    // Update is called once per frame
    void Update()
    {
        if (daily.activeSelf)
        {
            if(DataManager.dataManager.daily_complete >= 5 && DataManager.dataManager.daily_complete_reward == 0)
                rewardTxt.text = "완료\n" + DataManager.dataManager.daily_complete + " / " + 5;
            else if(DataManager.dataManager.daily_complete_reward == 1)
                rewardTxt.text = "수령 완료\n" + DataManager.dataManager.daily_complete + " / " + 5;
            else 
                rewardTxt.text = "진행중\n" + DataManager.dataManager.daily_complete + " / " + 5;
            rewardNum.text = "50";
        }
        else if (weekly.activeSelf)
        {
            if (DataManager.dataManager.weekly_complete >= 5 && DataManager.dataManager.weekly_complete_reward == 0)
                rewardTxt.text = "완료\n" + DataManager.dataManager.weekly_complete + " / " + 5;
            else if (DataManager.dataManager.weekly_complete_reward == 1 )
                rewardTxt.text = "수령 완료\n" + DataManager.dataManager.weekly_complete + " / " + 5;
            else
                rewardTxt.text = "진행중\n" + DataManager.dataManager.weekly_complete + " / " + 5;
            rewardNum.text = "100";
        }
        else if (achieve.activeSelf)
        {
            if(DataManager.dataManager.achieve_complete >= DataManager.dataManager.achieve_complete_reward)
                rewardTxt.text = "완료\n" + DataManager.dataManager.achieve_complete + " / " + DataManager.dataManager.achieve_complete_reward;
            else
                rewardTxt.text = "진행중\n" + DataManager.dataManager.achieve_complete + " / " + DataManager.dataManager.achieve_complete_reward;
            rewardNum.text = "200";
        }
    }

    public void GetReward()
    {
        if (daily.activeSelf)
        {
            if (DataManager.dataManager.daily_complete_reward >= 1)
                return;
            if (DataManager.dataManager.daily_complete < 5)
                return;
            DataManager.dataManager.IncreaseDailyData("reward");
            DataManager.dataManager.SubmitData("DailyQuest");
            DataManager.dataManager.IncreaseData("jem", 50);
            DataManager.dataManager.SubmitData("PlayerCurrency");
        }
        else if (weekly.activeSelf)
        {
            if (DataManager.dataManager.weekly_complete_reward >= 1)
                return;
            if (DataManager.dataManager.weekly_complete < 5)
                return;
            DataManager.dataManager.IncreaseWeeklyData("reward");
            DataManager.dataManager.SubmitData("WeeklyQuest");
            DataManager.dataManager.IncreaseData("jem", 100);
            DataManager.dataManager.SubmitData("PlayerCurrency");
        }
        else if (achieve.activeSelf)
        {
            if (DataManager.dataManager.achieve_complete < DataManager.dataManager.achieve_complete_reward)
                return;
            DataManager.dataManager.IncreaseAchieveData("reward");
            DataManager.dataManager.SubmitData("Achievement");
            DataManager.dataManager.IncreaseData("jem", 200);
            DataManager.dataManager.SubmitData("PlayerCurrency");
        }
    }
}
