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
        txt.text = "닉네임 : " + BackEnd.Backend.UserNickName +
            "\n\n슬라임 평균 파워\n" + DataManager.dataManager.slimeAveragePower + "\n( 100위 )" +
            "\n\n슬라임 최고 파워\n" + DataManager.dataManager.slimeMaxPower + "\n( 100위 )" +
            "\n\n슬라임 파워 합산\n" + DataManager.dataManager.slimeSumPower + "\n( 100위 )" +
            "\n\n공격력 : " + DataManager.dataManager.attack +
            "\n\n공격속도 : " + DataManager.dataManager.attackRate + "초" +
            "\n\n치명타 확률 : " + DataManager.dataManager.criticalChance + "%" +
            "\n\n치명타 공격력 : " + DataManager.dataManager.criticalAttack + "%" +
            "\n\n슬라임 파워 증가 : " + DataManager.dataManager.slimePower +
            "\n\n알 잠재력 증가 : " + DataManager.dataManager.eggPotential +
            "\n\n슬라임 출현 증가율 : " + ((500 - DataManager.dataManager.spawnTime) / 5) + "%";
    }
}
