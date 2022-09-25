using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ChangeNickname : MonoBehaviour
{
    public Button btn;
    public GameObject nicknameWindow;
    public GameObject error;
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
        DataManager.dataManager.GetDataFromBro("PlayerCurrency");
        if (DataManager.dataManager.jem < 100)
        {
            SoundManager.soundManager.DeniedSound();
            error.SetActive(true);
        }
        else
        {
            SoundManager.soundManager.ConfirmSound();
            nicknameWindow.SetActive(true);
        }
    }
}
