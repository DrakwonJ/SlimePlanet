using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_QuitBtn : MonoBehaviour
{
    Button btn;
    public GameObject list;
    public GameObject extraWindow;
    bool listOn = false;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {

        SoundManager.soundManager.DeclineSound();
        UIClearManager.clearUI.ClearClicked();
        if (extraWindow != null)
            extraWindow.SetActive(false);
        if(list.name == "BornSlime")
        {
            Destroy(list.transform.GetChild(3).gameObject);
        }
        list.SetActive(false);
    }
}
