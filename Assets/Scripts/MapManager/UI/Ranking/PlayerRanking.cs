using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using UnityEngine.UI;

public class PlayerRanking : MonoBehaviour
{
    public GameObject max;
    public GameObject sum;
    public GameObject avg;
    public string maxRank, avgRank, sumRank;
    public Text txt, powertxt;
    // Start is called before the first frame update
    void Start()
    {
        GetMyRank();
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (max.activeSelf)
        {
            txt.text = "�÷��̾� ��ŷ : " + maxRank + "��";
            powertxt.text = DataManager.dataManager.slimeMaxPower.ToString();
        }
        else if (avg.activeSelf)
        {
            txt.text = "�÷��̾� ��ŷ : " + avgRank + "��";
            powertxt.text = DataManager.dataManager.slimeAveragePower.ToString();
        }
        else if (sum.activeSelf)
        {
            txt.text = "�÷��̾� ��ŷ : " + sumRank + "��";
            powertxt.text = DataManager.dataManager.slimeSumPower.ToString();
        }
    }

    public void GetMyRank()
    {
        maxRank = Backend.URank.User.GetMyRank(DataManager.dataManager.maxRankingUUID).GetFlattenJSON()["rows"][0]["rank"].ToString();
        avgRank = Backend.URank.User.GetMyRank(DataManager.dataManager.maxRankingUUID).GetFlattenJSON()["rows"][0]["rank"].ToString();
        sumRank = Backend.URank.User.GetMyRank(DataManager.dataManager.maxRankingUUID).GetFlattenJSON()["rows"][0]["rank"].ToString();
    }
}
