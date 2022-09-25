using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MaingErrorMessage : MonoBehaviour
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

    public void FullMessage()
    {
        txt.text = "슬라임 보관함이\n가득 찼습니다";
    }

    public void LackChance()
    {
        txt.text = "교배 횟수를 초과하였습니다.";
    }

    public void LackJem()
    {
        txt.text = "다이아가 부족합니다";
    }
}
