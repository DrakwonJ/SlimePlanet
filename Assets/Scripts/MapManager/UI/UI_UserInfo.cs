using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_UserInfo : MonoBehaviour
{
    public Text txt;
    string userName = "text";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "�г��� : " + BackEnd.Backend.UserNickName +
            "\n\n������ ��� �Ŀ�\n" + DataManager.dataManager.slimeAveragePower + "\n( 100�� )" +
            "\n\n������ �ְ� �Ŀ�\n" + DataManager.dataManager.slimeMaxPower + "\n( 100�� )" +
            "\n\n������ �Ŀ� �ջ�\n" + DataManager.dataManager.slimeSumPower + "\n( 100�� )" +
            "\n\n���ݷ� : " + DataManager.dataManager.attack +
            "\n\n���ݼӵ� : " + DataManager.dataManager.attackRate + "��" +
            "\n\nġ��Ÿ Ȯ�� : " + DataManager.dataManager.criticalChance + "%" +
            "\n\nġ��Ÿ ���ݷ� : " + DataManager.dataManager.criticalAttack + "%" +
            "\n\n������ �Ŀ� ���� : " + DataManager.dataManager.slimePower +
            "\n\n�� ����� ���� : " + DataManager.dataManager.eggPotential +
            "\n\n������ ���� ������ : " + ((500 - DataManager.dataManager.spawnTime) / 5) + "%";
    }
}
