using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MenuList : MonoBehaviour
{
    Button btn;
    public GameObject list;
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
        if (listOn == false)
        {
            SoundManager.soundManager.EquipSound();
            list.SetActive(true);
            listOn = true;
        }
        else if (listOn == true)
        {
            SoundManager.soundManager.UnequipSound();
            list.SetActive(false);
            listOn = false;
        }
    }
}
