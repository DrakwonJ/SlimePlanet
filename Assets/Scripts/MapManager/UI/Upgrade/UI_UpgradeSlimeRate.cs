using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_UpgradeSlimeRate : MonoBehaviour
{
    public Text txt;
    public Text costTxt;
    public Button btn;
    public int upgradeCost;
    public Image img;

    // Start is called before the first frame update
    void Start()
    {
        upgradeCost = (525 - DataManager.dataManager.spawnTime) * 4;
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (DataManager.dataManager.spawnTime == 100)
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
            txt.text = "슬라임이 출현할\n확률을 올립니다\n" +
                ((500 - DataManager.dataManager.spawnTime)/5) + "% → " + ((525 - DataManager.dataManager.spawnTime)/5) + "%";
            costTxt.text = upgradeCost.ToString();
            setColor();
        }
    }

    public void OnClick()
    {
        DataManager.dataManager.GetDataFromBro("PlayerCurrency");
        if (DataManager.dataManager.jem >= upgradeCost)
        {
            SoundManager.soundManager.CreateSound();
            DataManager.dataManager.DecreaseData("spawnTime", 25);
            DataManager.dataManager.SubmitData();
            DataManager.dataManager.DecreaseData("jem", upgradeCost);
            DataManager.dataManager.IncreaseData("spendJem", upgradeCost);
            DataManager.dataManager.SubmitData("PlayerCurrency");
            if (DataManager.dataManager.daily_spendJem < 100)
            {
                DataManager.dataManager.IncreaseDailyData("spendJem", upgradeCost);
                DataManager.dataManager.SubmitData("DailyQuest");
            }
            if (DataManager.dataManager.weekly_spendJem < 500)
            {
                DataManager.dataManager.IncreaseWeeklyData("spendJem", upgradeCost);
                DataManager.dataManager.SubmitData("WeeklyQuest");
            }
            upgradeCost = (525 - DataManager.dataManager.spawnTime) * 4;
        }
        else
            return;
    }

    public void setColor()
    {
        if (DataManager.dataManager.jem >= upgradeCost)
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
