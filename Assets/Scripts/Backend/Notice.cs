using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using System;
using LitJson;
using UnityEngine.UI;

public class NoticeInfo
{
    public string title;
    public string contents;
    public DateTime postingDate;


    public override string ToString()
    {
        return $"title : {title}\n" +
        $"contents : {contents}\n" +
        $"postingDate : {postingDate}\n";
    }
}

public class Notice : MonoBehaviour
{
    public GameObject noticeMain;
    public GameObject noticePopup;
    public List<Button> btnList = new List<Button>();
    List<NoticeInfo> noticeList = new List<NoticeInfo>();

    // Start is called before the first frame update
    void Start()
    {
        BackendReturnObject bro = Backend.Notice.NoticeList();
        if (bro.IsSuccess())
        {
            Debug.Log(bro);
            JsonData jsonList = bro.FlattenRows();
            for(int i = 0; i < jsonList.Count; i++)
            {
                NoticeInfo noticeInfo = new NoticeInfo();
                noticeInfo.title = jsonList[i]["title"].ToString();
                noticeInfo.contents = jsonList[i]["content"].ToString();
                noticeInfo.postingDate = DateTime.Parse(jsonList[i]["postingDate"].ToString());
                noticeList.Add(noticeInfo);
                Debug.Log(noticeInfo.ToString());
                btnList[i].GetComponent<NoticePopup>().notice = noticeInfo;
            }
        }
        else
        {
            Debug.Log("서버 공통 에러 발생: " + bro.GetErrorCode());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (noticePopup.activeSelf)
            noticeMain.SetActive(false);
        else
            noticeMain.SetActive(true);
    }
}
