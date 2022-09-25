using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CatchChance : MonoBehaviour
{
    Text txt;
    // Start is called before the first frame update
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "¿À´Ã ³²Àº Àâ±â È½¼ö\n" + DataManager.dataManager.curChance + " / " + DataManager.dataManager.chance;
    }
}
