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
        txt.text = "������ ��������\n���� á���ϴ�";
    }

    public void LackChance()
    {
        txt.text = "���� Ƚ���� �ʰ��Ͽ����ϴ�.";
    }

    public void LackJem()
    {
        txt.text = "���̾ư� �����մϴ�";
    }
}
