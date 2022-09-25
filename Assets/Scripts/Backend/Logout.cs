using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logout : MonoBehaviour
{
    public Button btn;
    public Button confirmButton;
    public GameObject confirmWindow;
    public Text txt;
    public GameObject startUI;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(OnClick);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        SoundManager.soundManager.ConfirmSound();
        confirmWindow.SetActive(true);
        confirmButton.onClick.AddListener(ConfirmClick);
        txt.text = "로그아웃 하시겠습니까?";
    }

    public void ConfirmClick()
    {
        SoundManager.soundManager.DeclineSound();
        BackendReturnObject bro = Backend.BMember.Logout();
        if (bro.IsSuccess())
        {
            Debug.Log("Logout");
            confirmWindow.SetActive(false);
            transform.parent.gameObject.SetActive(false);
            startUI.SetActive(true);
            startUI.GetComponent<StartScene>().InitGameUI();
        }
        else
        {
            Debug.Log(bro.GetErrorCode());
        }
    }
}
