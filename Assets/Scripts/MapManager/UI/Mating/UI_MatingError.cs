using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MatingError : MonoBehaviour
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

    public void FullEggList()
    {
        txt.text = "�� �������� ���� á���ϴ�";
    }

    public void SameSlimeChoose()
    {
        txt.text = "���� �������� ������ �� �����ϴ�";
    }
}
