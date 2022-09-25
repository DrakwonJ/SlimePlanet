using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EggErrorMessage : MonoBehaviour
{
    public Text txt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SlimeBagMessage()
    {
        txt.text = "슬라임 보관함이\n가득 찼습니다";
    }

    public void LackJemMessage()
    {
        txt.text = "다이아가 부족합니다";
    }
}
