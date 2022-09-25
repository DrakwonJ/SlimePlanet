using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_IncubatorAddBtn : MonoBehaviour
{
    public Button btn;
    public GameObject window;
    public Text txt;
    int cost;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        cost = DataManager.dataManager.incubator * 200;
        txt.text = cost.ToString();
    }

    public GameObject errorMessage;
    void OnClick()
    {
        DataManager.dataManager.GetDataFromBro("PlayerCurrency");
        if (DataManager.dataManager.jem >= cost)
        {
            SoundManager.soundManager.ConfirmSound();
            DataManager.dataManager.IncreaseData("spendJem", cost);
            DataManager.dataManager.DecreaseData("jem", cost);
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
            EggManager.eggManager.IncubatorAdd();
            window.SetActive(false);
        }
        else // 다이아 부족 메세지
        {
            SoundManager.soundManager.DeniedSound();
            errorMessage.SetActive(true);
            errorMessage.GetComponent<UI_EggErrorMessage>().LackJemMessage();
            window.SetActive(false);
        }
    }
}
