using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SlimeBagAddImg : MonoBehaviour
{
    public int bag;
    public int cost;
    public Text text, costText;
    public Button btnOk, btnNo;
    // Start is called before the first frame update
    void Start()
    {
        btnOk.onClick.AddListener(OnClick);
        btnNo.onClick.AddListener(NoClick);
    }

    // Update is called once per frame
    void Update()
    {
        bag = DataManager.dataManager.slimeBag;
        cost = bag * 20;
        text.text = "º¸°üÇÔ ´Ã¸®±â\n" + bag + " ¡æ " + (bag + 5);
        costText.text = cost.ToString();
    }
    public GameObject lackJem;
    public void OnClick()
    {
        DataManager.dataManager.GetDataFromBro("PlayerCurrency");
        if(DataManager.dataManager.jem >= cost)
        {
            DataManager.dataManager.DecreaseData("jem", cost);
            DataManager.dataManager.IncreaseData("spendJem", cost);
            DataManager.dataManager.SubmitData("PlayerCurrency");
            DataManager.dataManager.IncreaseData("slimeBag", 5);
            DataManager.dataManager.SubmitData();
            if (DataManager.dataManager.daily_spendJem < 100)
            {
                DataManager.dataManager.IncreaseDailyData("spendJem", cost);
                DataManager.dataManager.SubmitData("DailyQuest");
            }
            if (DataManager.dataManager.weekly_spendJem < 500)
            {
                DataManager.dataManager.IncreaseWeeklyData("spendJem", cost);
                DataManager.dataManager.SubmitData("WeeklyQuest");
            }
            gameObject.SetActive(false);
            SoundManager.soundManager.ConfirmSound();
        }
        else
        {
            SoundManager.soundManager.DeniedSound();
            gameObject.SetActive(false);
            lackJem.SetActive(true);
        }
    }

    public void NoClick()
    {
        SoundManager.soundManager.DeclineSound();
        gameObject.SetActive(false);
    }
}
