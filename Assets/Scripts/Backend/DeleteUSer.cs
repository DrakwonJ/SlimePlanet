using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using UnityEngine.UI;

public class DeleteUSer : MonoBehaviour
{
    public Button btn;
    public Button btnConfirm;
    public GameObject ConfirmWindow;
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
        ConfirmWindow.SetActive(true);
        btnConfirm.onClick.AddListener(DeleteUser);
        txt.text = "���� ȸ��Ż�� �Ͻðڽ��ϱ�?\n7�ϰ��� �����Ⱓ �� �����˴ϴ�\n�� ���� �α��ν� Ż��� öȸ�˴ϴ�.";
    }

    public void DeleteUser()
    {
        SoundManager.soundManager.DeniedSound();
        BackendReturnObject bro = Backend.BMember.SignOut();
        if (bro.IsSuccess())
        {
            Debug.Log("ȸ��Ż��");
            ConfirmWindow.SetActive(false);
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
