using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EggCountTxt : MonoBehaviour
{
    public Text txt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "º¸À¯ ¾Ë °¹¼ö\n" + EggManager.eggManager.eggList.Count + " / " + DataManager.dataManager.eggBag;
    }
}
