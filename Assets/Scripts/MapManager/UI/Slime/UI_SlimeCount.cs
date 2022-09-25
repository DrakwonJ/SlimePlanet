using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SlimeCount : MonoBehaviour
{
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "보유 슬라임\n" + DataManager.dataManager.slimeCode.Count + " / " + DataManager.dataManager.slimeBag;
    }
}
