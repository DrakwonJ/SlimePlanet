using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BackEnd;

public class StartScene : MonoBehaviour
{
    public Image image;
    public Button GuestLogin;
    public Button GoogleLogin;
    public GameObject ui1, ui2, ui3, ui4, ui5, ui6, ui7;
    public bool loadOver = false;
    public GameObject CreateNickname;


    // Start is called before the first frame update
    void Start()
    {
        var bro = Backend.Initialize(true);
        GuestLogin.onClick.AddListener(GuestLoginMethod);
        if (bro.IsSuccess())
        {

        }
        else
        {
            Debug.Log("�ʱ�ȭ ����");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GuestLoginMethod()
    {
        BackendReturnObject bro = Backend.BMember.GuestLogin("�Խ�Ʈ �α������� �α�����");
        if (bro.IsSuccess())
        {
            Debug.Log("�Խ�Ʈ �α��ο� �����߽��ϴ�");
            Debug.Log(bro.GetStatusCode());
            DataManager.dataManager.GetDataFromBro("PlayerInfo");
            DataManager.dataManager.GetDataFromBro("SlimeRanking");
            DataManager.dataManager.GetDataFromBro("SlimeList");
            DataManager.dataManager.GetDataFromBro("PlayerCurrency");
            DataManager.dataManager.GetDataFromBro("EggList");
            DataManager.dataManager.GetDataFromBro("Achievement");
            DataManager.dataManager.GetDataFromBro("DailyQuest");
            DataManager.dataManager.GetDataFromBro("WeeklyQuest");
            DataManager.dataManager.GetRank();
            DataManager.dataManager.GetPost();
            PlanetManager.planetManager.InstantitatePlanet();
            EggManager.eggManager.SwitchCodetoEgg();
            Fade();
        }
        else if(bro.GetStatusCode() == "401")
        {
            Debug.Log("�������� �ʴ� ���̵� �Դϴ�.");
        }
        else if (bro.GetStatusCode() == "410")
        {
            Debug.Log("������ ���� �Դϴ�.");
        }
        else if (bro.GetStatusCode() == "403")
        {
            Debug.Log("������ ���� �Դϴ�.");
        }
    }

    public void Fade()
    {
        GuestLogin.gameObject.SetActive(false);
        GoogleLogin.gameObject.SetActive(false);
        image.gameObject.SetActive(true);
        StartCoroutine(FadeCoroutine());
    }

    IEnumerator FadeCoroutine()
    {
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0.5f, 0.5f, 0.5f, fadeCount);
        }

        ui1.gameObject.SetActive(true);
        ui2.gameObject.SetActive(true);
        ui3.gameObject.SetActive(true);
        ui4.gameObject.SetActive(true);
        ui5.gameObject.SetActive(true);
        ui6.gameObject.SetActive(true);
        ui7.gameObject.SetActive(true);

        while(fadeCount > 0.0f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0.5f, 0.5f, 0.5f, fadeCount);
        }

        image.gameObject.SetActive(false);
        gameObject.SetActive(false);
        if (Backend.UserNickName == "")
            CreateNickname.SetActive(true);
    }

    public void InitGameUI()
    {
        StartCoroutine(InitCoroutine());

    }

    IEnumerator InitCoroutine()
    {
        image.gameObject.SetActive(true);
        float fadeCount = 0;
        while(fadeCount < 1.0f){
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0.5f, 0.5f, 0.5f, fadeCount);
        }
        ui1.gameObject.SetActive(false);
        ui2.gameObject.SetActive(false);
        ui3.gameObject.SetActive(false);
        ui4.gameObject.SetActive(false);
        ui5.gameObject.SetActive(false);
        ui6.gameObject.SetActive(false);
        ui7.gameObject.SetActive(false);
        GuestLogin.gameObject.SetActive(true);
        GoogleLogin.gameObject.SetActive(true);
        while (fadeCount > 0.0f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0.5f, 0.5f, 0.5f, fadeCount);
        }
        image.gameObject.SetActive(false);
        if (Backend.UserNickName == "")
            CreateNickname.SetActive(true);
    }
}
