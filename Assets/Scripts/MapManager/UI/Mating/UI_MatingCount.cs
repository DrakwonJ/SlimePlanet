using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MatingCount : MonoBehaviour
{
    public Text txt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "¿À´Ã ³²Àº ±³¹è È½¼ö\n" + DataManager.dataManager.curMating + " / " + DataManager.dataManager.maxMating;    
    }
}
