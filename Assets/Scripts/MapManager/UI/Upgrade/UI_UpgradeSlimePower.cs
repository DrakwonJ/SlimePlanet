using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_UpgradeSlimePower : MonoBehaviour
{
    public Text txt;
    public Text costTxt;
    public Button btn;
    public int upgradeCost;
    public Image img;

    // Start is called before the first frame update
    void Start()
    {
        upgradeCost = (DataManager.dataManager.slimePower + 1) * 100;
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "획득하는 슬라임의\n파워를 올립니다\n" +
    DataManager.dataManager.slimePower + " → " + (DataManager.dataManager.slimePower + 1);
        costTxt.text = upgradeCost.ToString();
        setColor();
    }

    public void OnClick()
    {
        DataManager.dataManager.GetDataFromBro("PlayerCurrency");
        if (DataManager.dataManager.money >= upgradeCost)
        {
            SoundManager.soundManager.CreateSound();
            DataManager.dataManager.DecreaseData("money", upgradeCost);
            DataManager.dataManager.IncreaseData("spendMoney", upgradeCost);
            DataManager.dataManager.SubmitData("PlayerCurrency");
            DataManager.dataManager.IncreaseData("slimePower");
            DataManager.dataManager.SubmitData();
            if (DataManager.dataManager.daily_spendMoney < 500)
            {
                DataManager.dataManager.IncreaseDailyData("spendMoney", upgradeCost);
                DataManager.dataManager.SubmitData("DailyQuest");
            }
            if (DataManager.dataManager.weekly_spendMoney < 2500)
            {
                DataManager.dataManager.IncreaseWeeklyData("spendMoney", upgradeCost);
                DataManager.dataManager.SubmitData("WeeklyQuest");
            }
            upgradeCost = (DataManager.dataManager.slimePower + 1) * 100;
        }
        else
            return;
    }

    public void setColor()
    {
        if (DataManager.dataManager.money >= upgradeCost)
        {
            Color color = img.GetComponent<Image>().color;
            color.a = 1.0f;
            img.GetComponent<Image>().color = color;
        }
        else
        {
            Color color = img.GetComponent<Image>().color;
            color.a = 0.5f;
            img.GetComponent<Image>().color = color;
        }
    }
}
