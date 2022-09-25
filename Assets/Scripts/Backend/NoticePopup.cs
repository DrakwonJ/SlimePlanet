using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticePopup : MonoBehaviour
{
    public Button btn;
    public NoticeInfo notice;
    public GameObject noticeMain;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if(notice != null)
        {
            transform.GetChild(0).GetComponent<Text>().text = notice.title;
        }
        else
        {
            transform.GetChild(0).GetComponent<Text>().text = "";
        }
    }

    public void OnClick()
    {

        if (notice != null)
        {
            SoundManager.soundManager.SelectSound();
            noticeMain.SetActive(true);
            noticeMain.transform.GetChild(0).GetComponent<Transform>().GetChild(0).GetComponent<Text>().text = notice.title;
            noticeMain.transform.GetChild(1).GetComponent<Text>().text = notice.contents;
            noticeMain.transform.GetChild(2).GetComponent<Text>().text = notice.postingDate.ToString();
        }
    }
}
