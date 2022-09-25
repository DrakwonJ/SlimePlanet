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
        return Regex.IsMatch(nicknameInput.text, "^[0-9a-zA-Z°¡-ÆR]*$");
    }

    public void OnClickCreateName()
    {
            // ÇÑ±Û, ¿µ¾î, ¼ýÀÚ·Î¸¸ ´Ð³×ÀÓÀ» ¸¸µé¾ú´ÂÁö Ã¼Å©
            if (CheckNickname() == false)
            {
                Debug.Log("´Ð³×ÀÓÀº ÇÑ±Û, ¿µ¾î, ¼ýÀÚ·Î¸¸ ¸¸µé ¼ö ÀÖ½À´Ï´Ù.");
                errorText.text = "´Ð³×ÀÓÀº ÇÑ±Û, ¿µ¾î, ¼ýÀÚ·Î¸¸ ¸¸µé ¼ö ÀÖ½À´Ï´Ù.";
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
            Debug.Log("´Ð³×ÀÓ »ý¼º ¿Ï·á");
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
                        Debug.Log("ÀÌ¹Ì Áßº¹µÈ ´Ð³×ÀÓÀÌ ÀÖ´Â °æ¿ì");
                        errorText.text = "ÀÌ¹Ì Áßº¹µÈ ´Ð³×ÀÓÀÌ ÀÖ½À´Ï´Ù.";
                        break;

                    case "400":
                        if (bro.GetMessage().Contains("too long"))
                        {
                            Debug.Log("20ÀÚ ÀÌ»óÀÇ ´Ð³×ÀÓÀÎ °æ¿ì");
                            errorWindow.SetActive(true);
                            errorText.text = "´Ð³×ÀÓÀÌ ³Ê¹« ±é´Ï´Ù.";
                        }
                        else if (bro.GetMessage().Contains("blank"))
                        {
                            Debug.Log("´Ð³×ÀÓ¿¡ ¾Õ/µÚ °ø¹éÀÌ ÀÖ´Â°æ¿ì");
                            errorWindow.SetActive(true);
                            errorText.text = "´Ð³×ÀÓÀÌ ªR / µÚ °ø¹éÀÌ ÀÖ½À´Ï´Ù.";
                        }
                        break;

                    default:
                        Debug.Log("¼­¹ö °øÅë ¿¡·¯ ¹ß»ý: " + bro.GetErrorCode());
                        errorWindow.SetActive(true);
                        errorText.text = "¼­¹ö °øÅë ¿¡·¯ ¹ß»ý : " + bro.GetErrorCode();
                        break;
                }
            }
    }
}
