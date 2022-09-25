using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Reward : MonoBehaviour
{
    public Button btn;
    public int reward;
    public string rewardType;
    public string questType;
    public string period;
    public bool isCompleted = false;
    public Text rewardTxt;
    public bool isReward = false;
    // Start is called before the first frame update
    void Start()
    {
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(GetReward);
    }

    // Update is called once per frame
    void Update()
    {
        if (isReward == true)
        {
            rewardTxt.text = "수령 완료";
            btn.onClick.RemoveListener(GetReward);
        }
        else if (isCompleted == true)
            rewardTxt.text = "보상 받기";
        else if(isReward == false)
        {
            rewardTxt.text = "진행중";
        }
    }

    public void SetReward(string type, int num, string quest, string per, bool complete)
    {
        period = per;
        questType = quest;
        rewardType = type;
        reward = num;
        isReward = complete;
    }

    public void GetReward()
    {
        if (isCompleted == false)
            return;
        else
        {
            if (period == "Daily")
            {
                SoundManager.soundManager.CreateSound();
                DataManager.dataManager.IncreaseData(rewardType, reward);
                DataManager.dataManager.SubmitData("PlayerCurrency");
                if(rewardType == "money")
                {
                    if (DataManager.dataManager.daily_earnMoney < 500)
                        DataManager.dataManager.IncreaseDailyData("earnMoney", reward);
                }
                DataManager.dataManager.IncreaseDailyData("complete", questType);
                DataManager.dataManager.SubmitData("DailyQuest");
                if (rewardType == "money")
                {
                    if (DataManager.dataManager.weekly_earnMoney < 2500)
                    {
                        DataManager.dataManager.IncreaseWeeklyData("earnMoney", reward);
                        DataManager.dataManager.SubmitData("WeeklyQuest");
                    }
                }
                isReward = true;
                rewardTxt.text = "수령 완료";
                btn.onClick.RemoveListener(GetReward);
            }
            else if(period == "Weekly")
            {
                SoundManager.soundManager.CreateSound();
                DataManager.dataManager.IncreaseData(rewardType, reward);
                DataManager.dataManager.SubmitData("PlayerCurrency");
                if (rewardType == "money")
                {
                    if (DataManager.dataManager.weekly_earnMoney < 2500)
                        DataManager.dataManager.IncreaseWeeklyData("earnMoney", reward);
                }
                DataManager.dataManager.IncreaseWeeklyData("complete", questType);
                DataManager.dataManager.SubmitData("WeeklyQuest");
                if (rewardType == "money")
                {
                    if (DataManager.dataManager.weekly_earnMoney < 500)
                    {
                        DataManager.dataManager.IncreaseDailyData("earnMoney", reward);
                        DataManager.dataManager.SubmitData("DailyQuest");
                    }
                }
                isReward = true;
                rewardTxt.text = "수령 완료";
                btn.onClick.RemoveListener(GetReward);
            }
            else if(period == "Achieve")
            {
                SoundManager.soundManager.CreateSound();
                DataManager.dataManager.IncreaseData(rewardType, reward);
                DataManager.dataManager.SubmitData("PlayerCurrency");
                DataManager.dataManager.IncreaseAchieveData(questType);
                DataManager.dataManager.SubmitData("Achievement");
                if (rewardType == "money")
                {
                    if (DataManager.dataManager.weekly_earnMoney < 500)
                    {
                        DataManager.dataManager.IncreaseDailyData("earnMoney", reward);
                        DataManager.dataManager.SubmitData("DailyQuest");
                    }
                }

                if (rewardType == "money")
                {
                    if (DataManager.dataManager.weekly_earnMoney < 2500)
                    {
                        DataManager.dataManager.IncreaseWeeklyData("earnMoney", reward);
                        DataManager.dataManager.SubmitData("WeeklyQuest");
                    }
                }
                gameObject.transform.parent.parent.GetComponent<DailyQuest>().UpdateQuestList();
            }
        }
    }
}
