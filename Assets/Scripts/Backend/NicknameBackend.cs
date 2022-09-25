using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class NicknameBackend : MonoBehaviour
{

    public InputField nicknameInput;
    public Button btn;
    public GameObject errorWindow;
    public Text errorText;

    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(OnClickCreateName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool CheckNickname()
    {
        return Regex.IsMatch(nicknameInput.text, "^[0-9a-zA-Z��-�R]*$");
    }

    public void OnClickCreateName()
    {
            // �ѱ�, ����, ���ڷθ� �г����� ��������� üũ
            if (CheckNickname() == false)
            {
                Debug.Log("�г����� �ѱ�, ����, ���ڷθ� ���� �� �ֽ��ϴ�.");
                errorText.text = "�г����� �ѱ�, ����, ���ڷθ� ���� �� �ֽ��ϴ�.";
                errorWindow.SetActive(true);
                return;
            }
            BackendReturnObject bro;
        bool changed = true;
        if (Backend.UserNickName == "")
        {
            bro = Backend.BMember.CreateNickname(nicknameInput.text);
            changed = false;
        }
        else
        {
            bro = Backend.BMember.UpdateNickname(nicknameInput.text);
            changed = true;
        }

            if (bro.IsSuccess())
            {
            if (changed)
            {
                DataManager.dataManager.DecreaseData("jem", 100);
                DataManager.dataManager.IncreaseData("spendJem", 100);
                DataManager.dataManager.SubmitData("PlayerCurrency");
                if (DataManager.dataManager.daily_complete_spendJem < 100)
                {
                    DataManager.dataManager.IncreaseDailyData("spendJem", 100);
                    DataManager.dataManager.SubmitData("DailyQuest");
                }
                if (DataManager.dataManager.weekly_spendJem < 500)
                {
                    DataManager.dataManager.IncreaseWeeklyData("spendJem", 100);
                    DataManager.dataManager.SubmitData("WeeklyQuest");
                }
            }
            Debug.Log("�г��� ���� �Ϸ�");
            SoundManager.soundManager.CreateSound();
            gameObject.SetActive(false);
            }

            else
            {
                SoundManager.soundManager.DeniedSound();
                switch (bro.GetStatusCode())
                {
                    case "409":
                        errorWindow.SetActive(true);
                        Debug.Log("�̹� �ߺ��� �г����� �ִ� ���");
                        errorText.text = "�̹� �ߺ��� �г����� �ֽ��ϴ�.";
                        break;

                    case "400":
                        if (bro.GetMessage().Contains("too long"))
                        {
                            Debug.Log("20�� �̻��� �г����� ���");
                            errorWindow.SetActive(true);
                            errorText.text = "�г����� �ʹ� ��ϴ�.";
                        }
                        else if (bro.GetMessage().Contains("blank"))
                        {
                            Debug.Log("�г��ӿ� ��/�� ������ �ִ°��");
                            errorWindow.SetActive(true);
                            errorText.text = "�г����� �R / �� ������ �ֽ��ϴ�.";
                        }
                        break;

                    default:
                        Debug.Log("���� ���� ���� �߻�: " + bro.GetErrorCode());
                        errorWindow.SetActive(true);
                        errorText.text = "���� ���� ���� �߻� : " + bro.GetErrorCode();
                        break;
                }
            }
    }
}
