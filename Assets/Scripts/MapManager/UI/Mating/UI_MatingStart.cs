using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MatingStart : MonoBehaviour
{
    public Button btn;
    public GameObject errorMsg;

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
        if (DataManager.dataManager.eggBag == EggManager.eggManager.incubatorList.Count)
        {
            SoundManager.soundManager.DeniedSound();
            errorMsg.SetActive(true);
            errorMsg.GetComponent<UI_MaingErrorMessage>().FullMessage();
        }
        else if (DataManager.dataManager.curMating > 0)
            MatingManager.matingManager.StartMating();
        else
        {
            SoundManager.soundManager.DeniedSound();
            errorMsg.SetActive(true);
            errorMsg.GetComponent<UI_MaingErrorMessage>().LackChance();
        }
    }
}
