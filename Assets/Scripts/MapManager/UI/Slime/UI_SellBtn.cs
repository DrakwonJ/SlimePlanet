using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SellBtn : MonoBehaviour
{
    public Text txt;
    Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(ClickSell);
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = MoneyManager.moneyManager.sellMoney.ToString();
    }

    public void ClickSell()
    {
        SoundManager.soundManager.SellSound();
        MoneyManager.moneyManager.SellSlime();
    }
}
