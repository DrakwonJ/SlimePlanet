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
        txt.text = "������ ��������\n���� á���ϴ�";
    }

    public void LackJemMessage()
    {
        txt.text = "���̾ư� �����մϴ�";
    }
}
