using BackEnd;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBackend : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var bro = Backend.Initialize(true);
        /*
        if (bro.IsSuccess())
        {
            // �ʱ�ȭ ���� �� ����
            Debug.Log("�ʱ�ȭ ����!");
            CustomSignUp();
        }
        else
        {
            // �ʱ�ȭ ���� �� ����
            Debug.LogError("�ʱ�ȭ ����!");
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�ʱ�ȭ ���� ���� ��ư ���� ���� �Լ� ����
    public void CustomSignUp()
    {
        string id = "user1"; // ���ϴ� ���̵�
        string password = "1234"; // ���ϴ� ��й�ȣ

        var bro = Backend.BMember.CustomSignUp(id, password);
        if (bro.IsSuccess())
        {
            Debug.Log("ȸ������ ����!");
        }
        else
        {
            Debug.LogError("ȸ������ ����!");
            Debug.LogError(bro); // �ڳ��� �������̽��� �α׷� �����ݴϴ�.
        }
    }
}