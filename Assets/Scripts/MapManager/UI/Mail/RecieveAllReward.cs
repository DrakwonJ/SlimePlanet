using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecieveAllReward : MonoBehaviour
{
    public Button btn;
    public ShowMailList listUp;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(GetAllReward);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetAllReward()
    {
        int jemNum = 0;
        int moneyNum = 0;
        var reveiveBro = BackEnd.Backend.UPost.ReceivePostItemAll(BackEnd.PostType.Admin);
        if (reveiveBro.IsSuccess())
        {
            for (int i = 0; i < DataManager.dataManager.postItemList.Count; i++)
            {
                if (DataManager.dataManager.postItemList[i].postType == BackEnd.PostType.Rank)
                    continue;
                else if (DataManager.dataManager.postItemList[i].rewardType == "jem")
                    jemNum += DataManager.dataManager.postItemList[i].rewardNum;
                else if (DataManager.dataManager.postItemList[i].rewardType == "money")
                    moneyNum += DataManager.dataManager.postItemList[i].rewardNum;
            }
        }

        reveiveBro = BackEnd.Backend.UPost.ReceivePostItemAll(BackEnd.PostType.Rank);
        if (reveiveBro.IsSuccess())
        {
            for (int i = 0; i < DataManager.dataManager.postItemList.Count; i++)
            {
                if (DataManager.dataManager.postItemList[i].postType == BackEnd.PostType.Admin)
                    continue;
                else if (DataManager.dataManager.postItemList[i].rewardType == "jem")
                    jemNum += DataManager.dataManager.postItemList[i].rewardNum;
                else if (DataManager.dataManager.postItemList[i].rewardType == "money")
                    moneyNum += DataManager.dataManager.postItemList[i].rewardNum;
            }
        }

        DataManager.dataManager.postItemList.Clear();
        if (jemNum > 0)
            DataManager.dataManager.IncreaseData("jem", jemNum);
        if (moneyNum > 0)
            DataManager.dataManager.IncreaseData("money", moneyNum);
        if (moneyNum > 0 || jemNum > 0)
            DataManager.dataManager.SubmitData("PlayerCurrency");
        listUp.ListUpMail();
    }
}
