using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Hp : MonoBehaviour
{
    CreateMonster spawnPool;
    //SlimeInfo slimeInfo;
    public Text hpText;
    public Image hpBar;
    float ratio;
    // Start is called before the first frame update
    void Start()
    {
       spawnPool = GameObject.Find("SpawningPool").GetComponent<CreateMonster>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnPool.spawnMon == null)
            return;
        hpText.text = "HP : " + spawnPool.spawnMon.GetComponent<SlimeInfo>().currentHp.ToString() + " / " + spawnPool.spawnMon.GetComponent<SlimeInfo>().maxHp.ToString();
        ratio = (float)spawnPool.spawnMon.GetComponent<SlimeInfo>().currentHp / (float)spawnPool.spawnMon.GetComponent<SlimeInfo>().maxHp;
        hpBar.fillAmount = ratio;
    }
}
