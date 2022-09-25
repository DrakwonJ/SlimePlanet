using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefreshRank : MonoBehaviour
{
    public DateTime refreshTime;
    public int coolTime = 600;
    public int diffTime;
    public Text timeText;
    Button btn;
    public GameObject playerRank;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Refresh);
        refreshTime = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        diffTime = (DateTime.Now - refreshTime).Seconds;
        if(diffTime <= 600)
        {
            timeText.text = (((600 - diffTime) / 60)).ToString("00") + " : " + ((600 - diffTime) % 60).ToString("00");
        }
        else
        {
            timeText.text = "갱신 가능";
        }
    }

    public void Refresh()
    {
        if (diffTime <= 600)
            return;
        else
        {
            DataManager.dataManager.GetRank();
            playerRank.GetComponent<PlayerRanking>().GetMyRank();
            refreshTime = DateTime.Now;
        }
    }
}
