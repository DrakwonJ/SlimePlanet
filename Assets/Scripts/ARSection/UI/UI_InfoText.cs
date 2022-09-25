using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InfoText : MonoBehaviour
{
    public Text infoText;
    SlimeInfo slimeInfo;
    CreateMonster spawnPool;
    // Start is called before the first frame update
    void Start()
    {
        spawnPool = GameObject.Find("SpawningPool").GetComponent<CreateMonster>();
        slimeInfo = spawnPool.spawnMon.GetComponent<SlimeInfo>();
        infoText = gameObject.GetComponent<Text>();
        infoText.text = "Slime Code : " + slimeInfo.slimeCode.ToString() + "\n\n"
    + "HP : " + slimeInfo.maxHp.ToString() + "\n\n"
    + "Power : " + slimeInfo.power.ToString() + "\n\n"
    + "Element : " + slimeInfo.type.ToString() + "\n\n"
    + "Character : " + slimeInfo.pool.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
