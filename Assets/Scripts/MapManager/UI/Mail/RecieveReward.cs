using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecieveReward : MonoBehaviour
{
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(GetReward);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetReward()
    {
        UPostItem Upost = gameObject.transform.parent.gameObject.GetComponent<MailContent>().mail;
        var receiveBro = BackEnd.Backend.UPost.ReceivePostItem(Upost.postType, Upost.inDate);
        if (receiveBro.IsSuccess())
        {
            SoundManager.soundManager.CreateSound();
            if(Upost.rewardType == "jem")
            {
                DataManager.dataManager.IncreaseData("jem",Upost.rewardNum);
            }
            else if(Upost.rewardType == "money")
            {
                DataManager.dataManager.IncreaseData("money", Upost.rewardNum);
            }
            DataManager.dataManager.SubmitData("PlayerCurrency");
            DataManager.dataManager.postItemList.Remove(Upost);
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
