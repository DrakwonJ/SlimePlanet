using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CountChance : MonoBehaviour
{
    public Text txt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "¿À´Ã ³²Àº Àâ±â È½¼ö\n" + 
            DataManager.dataManager.curChance.ToString() + " / " + DataManager.dataManager.chance.ToString();
    }
}
