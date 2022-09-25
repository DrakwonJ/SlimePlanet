using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BackEnd;

public class UI_IncreaseMating : MonoBehaviour
{
    public Button btn;
    public Text costTxt;
    public GameObject errorMsg;
    int cost;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        cost = (DataManager.dataManager.maxMating - 2) * 100;
        costTxt.text = cost.ToString();
    }

    public void OnClick()
    {
        DataManager.dataManager.GetDataFromBro("PlayerCurrency");
        if(DataManager.dataManager.jem >= cost)
        {
            SoundManager.soundManager.ConfirmSound();
            DataManager.dataManager.IncreaseData("maxMating");
            DataManager.dataManager.IncreaseData("curMating");
            DataManager.dataManager.SubmitData();
            DataManager.dataManager.DecreaseData("jem", cost);
            DataManager.dataManager.IncreaseData("spendJem", cost);
            DataManager.dataManager.SubmitData("PlayerCurrency");
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
        }
        else
        {
            SoundManager.soundManager.DeniedSound();
            errorMsg.SetActive(true);
            errorMsg.GetComponent<UI_MaingErrorMessage>().LackJem();
            gameObject.SetActive(false);
        }
    }
}
