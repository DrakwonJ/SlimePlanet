using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BackEnd;

public class UI_ChanceIncrease : MonoBehaviour
{
    public Button btn;
    public GameObject lackJem;
    public Text costText;
    int cost;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        cost = (DataManager.dataManager.chance - 4) * 100;
        costText.text = cost.ToString();
    }

    public void OnClick()
    {
        DataManager.dataManager.GetDataFromBro("PlayerCurrency");
        if(DataManager.dataManager.jem >= cost)
        {
            DataManager.dataManager.IncreaseData("chance");
            DataManager.dataManager.IncreaseData("curChance");
            DataManager.dataManager.SubmitData();
            DataManager.dataManager.DecreaseData("jem", cost);
            DataManager.dataManager.IncreaseData("spendJem", cost);
            DataManager.dataManager.SubmitData("PlayerCurrency");
            if (DataManager.dataManager.daily_spendJem < 100)
            {
                DataManager.dataManager.IncreaseDailyData("spendJem", cost);
                DataManager.dataManager.SubmitData("DailyQuest");
            }
            if (DataManager.dataManager.weekly_spendJem < 2500)
            {
                DataManager.dataManager.IncreaseWeeklyData("spendJem", cost);
                DataManager.dataManager.SubmitData("WeeklyQuest");
            }
            btn.GetComponent<AudioSource>().volume = SoundManager.soundManager.effectVolume;
            btn.GetComponent<AudioSource>().Play();
            gameObject.SetActive(false);
        }
        else
        {
            lackJem.SetActive(true);
            lackJem.GetComponent<UI_MaingErrorMessage>().LackJem();
            lackJem.GetComponent<AudioSource>().volume = SoundManager.soundManager.effectVolume;
            lackJem.GetComponent<AudioSource>().Play();
            gameObject.SetActive(false);
        }
    }
}
