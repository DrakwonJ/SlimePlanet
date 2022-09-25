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
        txt.text = "정말 회원탈퇴를 하시겠습니까?\n7일간의 유예기간 후 삭제됩니다\n그 전에 로그인시 탈퇴는 철회됩니다.";
    }

    public void DeleteUser()
    {
        SoundManager.soundManager.DeniedSound();
        BackendReturnObject bro = Backend.BMember.SignOut();
        if (bro.IsSuccess())
        {
            Debug.Log("회원탈퇴");
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
