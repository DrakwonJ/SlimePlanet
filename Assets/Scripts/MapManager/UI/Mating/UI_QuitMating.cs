using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_QuitMating : MonoBehaviour
{
    Button btn;
    public GameObject list;
    public GameObject extraWindow;
    public GameObject errorMessage;
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
        if (MatingManager.matingManager.targetSlot1.transform.childCount != 0)
            Destroy(MatingManager.matingManager.targetSlot1.transform.GetChild(0).gameObject);
        if (MatingManager.matingManager.targetSlot2.transform.childCount != 0)
            Destroy(MatingManager.matingManager.targetSlot2.transform.GetChild(0).gameObject);
        if (MatingManager.matingManager.egg != null)
        {
            MatingManager.matingManager.egg.transform.localScale = new Vector3(1,1,1);
            MatingManager.matingManager.egg.transform.position = new Vector3(0, 0, 0);
        }
        SoundManager.soundManager.DeclineSound();
        extraWindow.SetActive(false);
        list.SetActive(false);
        errorMessage.SetActive(false);
        MatingManager.matingManager.matingState = false;    
    }
}
