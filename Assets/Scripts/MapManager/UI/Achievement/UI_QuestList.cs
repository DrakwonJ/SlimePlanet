using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_QuestList : MonoBehaviour
{
    public Image rewardImg;
    public Text rewardTxt;
    public Text questTxt;
    public Button rewardBtn;
    public GameObject sliderProgress;
    public Sprite jemImg;
    public Sprite coinImg;
    public bool isCompleted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void questListUp(string type, string content)
    {
        if (type == "Daily")
        {
            switch (content)
            {
                case "catchSlime":
                    rewardImg.sprite = coinImg;
                    rewardTxt.text = "100";
                    if (DataManager.dataManager.daily_complete_catch == 1)
                        isCompleted = true;
                    rewardBtn.gameObject.GetComponent<UI_Reward>().SetReward("money", 100,"catchSlime", "Daily", isCompleted);
                    questTxt.text = "슬라임 잡기";
                    sliderProgress.GetComponent<UI_ProgreeBar>().SetProgressBar(DataManager.dataManager.daily_catch, 3);
                    break;
                case "matingTime":
                    rewardImg.sprite = coinImg;
                    rewardTxt.text = "100";
                    if (DataManager.dataManager.daily_complete_mate == 1)
                        isCompleted = true;
                    rewardBtn.gameObject.GetComponent<UI_Reward>().SetReward("money", 100, "matingTime", "Daily", isCompleted);
                    questTxt.text = "슬라임 교배 하기";
                    sliderProgress.GetComponent<UI_ProgreeBar>().SetProgressBar(DataManager.dataManager.daily_mate, 2);
                    break;
                case "bornTime":
                    rewardImg.sprite = coinImg;
                    rewardTxt.text = "100";
                    if (DataManager.dataManager.daily_complete_born == 1)
                        isCompleted = true;
                    rewardBtn.gameObject.GetComponent<UI_Reward>().SetReward("money", 100, "bornTime", "Daily", isCompleted);
                    questTxt.text = "슬라임 알 부화하기";
                    sliderProgress.GetComponent<UI_ProgreeBar>().SetProgressBar(DataManager.dataManager.daily_born, 1);
                    break;
                case "earnMoney":
                    rewardImg.sprite = coinImg;
                    rewardTxt.text = "100";
                    if (DataManager.dataManager.daily_complete_earnMoney == 1)
                        isCompleted = true;
                    rewardBtn.gameObject.GetComponent<UI_Reward>().SetReward("money", 100, "earnMoney", "Daily", isCompleted);
                    questTxt.text = "코인 획득하기";
                    sliderProgress.GetComponent<UI_ProgreeBar>().SetProgressBar(DataManager.dataManager.daily_earnMoney, 500);
                    break;
                case "spendMoney":
                    rewardImg.sprite = coinImg;
                    rewardTxt.text = "100";
                    if (DataManager.dataManager.daily_complete_spendMoney == 1)
                        isCompleted = true;
                    rewardBtn.gameObject.GetComponent<UI_Reward>().SetReward("money", 100, "spendMoney", "Daily", isCompleted);
                    questTxt.text = "코인 소비하기";
                    sliderProgress.GetComponent<UI_ProgreeBar>().SetProgressBar(DataManager.dataManager.daily_spendMoney, 500);
                    break;
                case "catchSlime2":
                    rewardImg.sprite = coinImg;
                    rewardTxt.text = "100";
                    if (DataManager.dataManager.daily_complete_catch2 == 1)
                        isCompleted = true;
                    rewardBtn.gameObject.GetComponent<UI_Reward>().SetReward("money", 100, "catchSlime2", "Daily", isCompleted);
                    questTxt.text = "슬라임 잡기";
                    sliderProgress.GetComponent<UI_ProgreeBar>().SetProgressBar(DataManager.dataManager.daily_catch2, 5);
                    break;
                case "spendJem":
                    rewardImg.sprite = jemImg;
                    rewardTxt.text = "20";
                    if (DataManager.dataManager.daily_complete_spendJem== 1)
                        isCompleted = true;
                    rewardBtn.gameObject.GetComponent<UI_Reward>().SetReward("jem", 100, "spendJem", "Daily", isCompleted);
                    questTxt.text = "젬 소비하기";
                    sliderProgress.GetComponent<UI_ProgreeBar>().SetProgressBar(DataManager.dataManager.daily_spendJem, 100);
                    break;
                case "watchAd":
                    rewardImg.sprite = jemImg;
                    rewardTxt.text = "20";
                    if (DataManager.dataManager.daily_complete_ad == 1)
                        isCompleted = true;
                    rewardBtn.gameObject.GetComponent<UI_Reward>().SetReward("jem", 100, "watchAd", "Daily", isCompleted);
                    questTxt.text = "광고 시청하기";
                    sliderProgress.GetComponent<UI_ProgreeBar>().SetProgressBar(DataManager.dataManager.daily_ad, 1);
                    break;
            }
        }
        else if(type == "Weekly")
        {
            switch (content)
            {
                case "catchSlime":
                    rewardImg.sprite = coinImg;
                    rewardTxt.text = "500";
                    if (DataManager.dataManager.weekly_complete_catch == 1)
                        isCompleted = true;
                    rewardBtn.gameObject.GetComponent<UI_Reward>().SetReward("money", 100, "catchSlime", "Weekly", isCompleted);
                    questTxt.text = "슬라임 잡기";
                    sliderProgress.GetComponent<UI_ProgreeBar>().SetProgressBar(DataManager.dataManager.weekly_catch, 15);
                    break;
                case "matingTime":
                    rewardImg.sprite = coinImg;
                    rewardTxt.text = "500";
                    if (DataManager.dataManager.weekly_complete_mate == 1)
                        isCompleted = true;
                    rewardBtn.gameObject.GetComponent<UI_Reward>().SetReward("money", 100, "matingTime", "Weekly", isCompleted);
                    questTxt.text = "슬라임 교배 하기";
                    sliderProgress.GetComponent<UI_ProgreeBar>().SetProgressBar(DataManager.dataManager.weekly_mate, 10);
                    break;
                case "bornTime":
                    rewardImg.sprite = coinImg;
                    rewardTxt.text = "500";
                    if (DataManager.dataManager.weekly_complete_born == 1)
                        isCompleted = true;
                    rewardBtn.gameObject.GetComponent<UI_Reward>().SetReward("money", 100, "bornTime", "Weekly", isCompleted);
                    questTxt.text = "슬라임 알 부화하기";
                    sliderProgress.GetComponent<UI_ProgreeBar>().SetProgressBar(DataManager.dataManager.weekly_born, 5);
                    break;
                case "earnMoney":
                    rewardImg.sprite = coinImg;
                    rewardTxt.text = "500";
                    if (DataManager.dataManager.weekly_complete_earnMoney == 1)
                        isCompleted = true;
                    rewardBtn.gameObject.GetComponent<UI_Reward>().SetReward("money", 100, "earnMoney", "Weekly", isCompleted);
                    questTxt.text = "코인 획득하기";
                    sliderProgress.GetComponent<UI_ProgreeBar>().SetProgressBar(DataManager.dataManager.weekly_earnMoney, 2500);
                    break;
                case "spendMoney":
                    rewardImg.sprite = coinImg;
                    rewardTxt.text = "500";
                    if (DataManager.dataManager.weekly_complete_spendMoney == 1)
                        isCompleted = true;
                    rewardBtn.gameObject.GetComponent<UI_Reward>().SetReward("money", 100, "spendMoney", "Weekly", isCompleted);
                    questTxt.text = "코인 소비하기";
                    sliderProgress.GetComponent<UI_ProgreeBar>().SetProgressBar(DataManager.dataManager.weekly_spendMoney, 2500);
                    break;
                case "catchSlime2":
                    rewardImg.sprite = coinImg;
                    rewardTxt.text = "500";
                    if (DataManager.dataManager.weekly_complete_catch2 == 1)
                        isCompleted = true;
                    rewardBtn.gameObject.GetComponent<UI_Reward>().SetReward("money", 100, "catchSlime2", "Weekly", isCompleted);
                    questTxt.text = "슬라임 잡기";
                    sliderProgress.GetComponent<UI_ProgreeBar>().SetProgressBar(DataManager.dataManager.weekly_catch2, 25);
                    break;
                case "spendJem":
                    rewardImg.sprite = jemImg;
                    rewardTxt.text = "100";
                    if (DataManager.dataManager.weekly_complete_spendJem == 1)
                        isCompleted = true;
                    rewardBtn.gameObject.GetComponent<UI_Reward>().SetReward("jem", 100, "spendJem", "Weekly", isCompleted);
                    questTxt.text = "젬 소비하기";
                    sliderProgress.GetComponent<UI_ProgreeBar>().SetProgressBar(DataManager.dataManager.weekly_spendJem, 500);
                    break;
                case "watchAd":
                    rewardImg.sprite = jemImg;
                    rewardTxt.text = "100";
                    if (DataManager.dataManager.weekly_complete_ad == 1)
                        isCompleted = true;
                    rewardBtn.gameObject.GetComponent<UI_Reward>().SetReward("jem", 100, "watchAd", "Weekly", isCompleted);
                    questTxt.text = "광고 시청하기";
                    sliderProgress.GetComponent<UI_ProgreeBar>().SetProgressBar(DataManager.dataManager.weekly_ad, 5);
                    break;
            }

        }

        else if(type == "Achieve")
        {
            switch (content)
            {
                case "catchSlime":
                    rewardImg.sprite = jemImg;
                    rewardTxt.text = "100";
                    rewardBtn.gameObject.GetComponent<UI_Reward>().SetReward("jem", 100, "catchSlime", "Achieve", false);
                    questTxt.text = "슬라임 잡기";
                    sliderProgress.GetComponent<UI_ProgreeBar>().SetProgressBar(DataManager.dataManager.totalCatch, DataManager.dataManager.achieve_catch);
                    break;
                case "matingTime":
                    rewardImg.sprite = jemImg;
                    rewardTxt.text = "100";
                    rewardBtn.gameObject.GetComponent<UI_Reward>().SetReward("jem", 100, "matingTime", "Achieve", false);
                    questTxt.text = "슬라임 교배 하기";
                    sliderProgress.GetComponent<UI_ProgreeBar>().SetProgressBar(DataManager.dataManager.totalMating, DataManager.dataManager.achieve_mating);
                    break;
                case "bornTime":
                    rewardImg.sprite = jemImg;
                    rewardTxt.text = "100";
                    rewardBtn.gameObject.GetComponent<UI_Reward>().SetReward("jem", 100, "bornTime", "Achieve", false);
                    questTxt.text = "슬라임 알 부화하기";
                    sliderProgress.GetComponent<UI_ProgreeBar>().SetProgressBar(DataManager.dataManager.totalBorn, DataManager.dataManager.achieve_born);
                    break;
                case "avgPower":
                    rewardImg.sprite = jemImg;
                    rewardTxt.text = "100";
                    rewardBtn.gameObject.GetComponent<UI_Reward>().SetReward("jem", 100, "avgPower", "Achieve", false);
                    questTxt.text = "슬라임 평균 파워 달성하기";
                    sliderProgress.GetComponent<UI_ProgreeBar>().SetProgressBar(DataManager.dataManager.slimeAveragePower, DataManager.dataManager.achieve_avgPower);
                    break;
                case "spendMoney":
                    rewardImg.sprite = jemImg;
                    rewardTxt.text = "100";
                    rewardBtn.gameObject.GetComponent<UI_Reward>().SetReward("jem", 100, "spendMoney", "Achieve", false);
                    questTxt.text = "골드 소비하기";
                    sliderProgress.GetComponent<UI_ProgreeBar>().SetProgressBar(DataManager.dataManager.spendMoney, DataManager.dataManager.achieve_spendMoney);
                    break;
                case "sumPower":
                    rewardImg.sprite = jemImg;
                    rewardTxt.text = "100";
                    rewardBtn.gameObject.GetComponent<UI_Reward>().SetReward("jem", 100, "sumPower", "Achieve", false);
                    questTxt.text = "슬라임 파워 총합 달성하기";
                    sliderProgress.GetComponent<UI_ProgreeBar>().SetProgressBar(DataManager.dataManager.slimeSumPower, DataManager.dataManager.achieve_sumPower);
                    break;
                case "spendJem":
                    rewardImg.sprite = jemImg;
                    rewardTxt.text = "100";
                    rewardBtn.gameObject.GetComponent<UI_Reward>().SetReward("jem", 100, "spendJem", "Achieve", false);
                    questTxt.text = "젬 소비하기";
                    sliderProgress.GetComponent<UI_ProgreeBar>().SetProgressBar(DataManager.dataManager.spendJem, DataManager.dataManager.achieve_spendJem);
                    break;
                case "maxPower":
                    rewardImg.sprite = jemImg;
                    rewardTxt.text = "100";
                    rewardBtn.gameObject.GetComponent<UI_Reward>().SetReward("jem", 100, "maxPower", "Achieve", isCompleted);
                    questTxt.text = "슬라임 최고 파워 달성하기";
                    sliderProgress.GetComponent<UI_ProgreeBar>().SetProgressBar(DataManager.dataManager.slimeMaxPower, DataManager.dataManager.achieve_maxPower);
                    break;
            }
        }
    }
}
