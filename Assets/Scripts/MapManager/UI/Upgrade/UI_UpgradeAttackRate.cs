using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_UpgradeAttackRate : MonoBehaviour
{
    public Text txt;
    public Text costTxt;
    public Button btn;
    public int upgradeCost;
    public Image img;
    // Start is called before the first frame update
    void Start()
    {
        upgradeCost = (int)(5000 * (2.1f - DataManager.dataManager.attackRate));
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (DataManager.dataManager.attackRate == 0.5f)
        {
            txt.text = "최대 업그레이드 완료";
            costTxt.text = " ";
            btn.onClick.RemoveListener(OnClick);
            Color color = img.GetComponent<Image>().color;
            color.a = 0.5f;
            img.GetComponent<Image>().color = color;
        }
        else
        {
            txt.text = "슬라임을 잡을 때\n공격속도를 올립니다\n" +
                DataManager.dataManager.attackRate + " → " + (DataManager.dataManager.attackRate - 0.1f);
            costTxt.text = upgradeCost.ToString();
            setColor();
        }
        
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
            DataManager.dataManager.DecreaseData("attackRate", 1);
            DataManager.dataManager.SubmitData();
            if (DataManager.dataManager.daily_earnMoney < 500)
            {
                DataManager.dataManager.IncreaseDailyData("earnMoney", upgradeCost);
                DataManager.dataManager.SubmitData("DailyQuest");
            }
            if (DataManager.dataManager.weekly_earnMoney < 2500)
            {
                DataManager.dataManager.IncreaseWeeklyData("earnMoney", upgradeCost);
                DataManager.dataManager.SubmitData("WeeklyQuest");
            }
            upgradeCost = (int)(5000 * (2.1f - DataManager.dataManager.attackRate));
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
