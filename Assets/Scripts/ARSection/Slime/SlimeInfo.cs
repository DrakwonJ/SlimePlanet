using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Define;
using Random = UnityEngine.Random;

public class SlimeInfo : MonoBehaviour
{
    public static SlimeInfo slimeInfo;
    public SlimeType type;
    public SlimePool pool;
    public int power = 0;
    CreateMonster spawnPool;
    public string slimeCode;
    public int maxHp;
    public int currentHp;
    public long spawnDate;
    public int slimeListNum;

    public bool Ui_on = false;
    public GameObject UI1;
    public GameObject UI2;
    public GameObject UI3;

    private void Awake()
    {
        if (slimeInfo == null)
            slimeInfo = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "ARScene") { 
        spawnPool = GameObject.Find("SpawningPool").GetComponent<CreateMonster>();
            int typeNum = spawnPool.slimeNum;
            pool = (SlimePool)typeNum;

            float r = spawnPool.colorCoder;
            float g = spawnPool.colorCodeg;
            float b = spawnPool.colorCodeb;

            if (r > g && r > b)
                type = Define.SlimeType.fire;
            else if (g > b && g > r)
                type = Define.SlimeType.water;
            else if (b > r && b > g)
                type = Define.SlimeType.grass;
            else if (r == g && r != b)
                type = Define.SlimeType.grassfire;
            else if (r == b && r != g)
                type = Define.SlimeType.firewater;
            else if (g == b && g != r)
                type = Define.SlimeType.watergrass;
            else if (g == b && b == r)
                type = Define.SlimeType.triple;

            setPower();
            slimeListNum = CheckSlimeList();
            CreateCode(r, g, b);
            maxHp = power;
            currentHp = maxHp;
            spawnDate = long.Parse(DateTime.Now.ToString("yyyyMMddHHmm"));
        }
        else if(SceneManager.GetActiveScene().name == "MainScene")
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setPower()
    {
        power += UnityEngine.Random.Range(0, 50);
        switch(type)
        {
            case SlimeType.fire:
            case SlimeType.water:
            case SlimeType. grass:
                power += UnityEngine.Random.Range(0, 50);
                break;
            case SlimeType.firewater:
            case SlimeType.grassfire:
            case SlimeType.watergrass:
                power += UnityEngine.Random.Range(25, 50);
                break;
            case SlimeType.triple:
                power += UnityEngine.Random.Range(50, 100);
                break;
        }
        power += DataManager.dataManager.slimePower;
    }

    public void CreateCode(float r, float g, float b)
    {
        int val = (int)pool;
        if (val < 10)
            slimeCode = "0" + val.ToString();
        else
            slimeCode = val.ToString();
        val = (int)type;
        slimeCode += val.ToString();
        int val1 = (int)(r * 100);
        int val2 = (int)(g * 100);
        int val3 = (int)(b * 100);
        slimeCode = slimeCode + val1.ToString("000") + val2.ToString("000") + val3.ToString("000");
        slimeCode += power.ToString("000") + DateTime.Now.ToString(("yyyyMMddHHmm")) + CheckSlimeList().ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        int crit = Random.Range(0, 101);
        if(crit < DataManager.dataManager.criticalChance)
        {
            currentHp -= (int)(DataManager.dataManager.attack * DataManager.dataManager.criticalAttack / 100);
        }
        else 
            currentHp -= DataManager.dataManager.attack;//PlayerInfo.playerInfo.attack;
        if (currentHp < 0)
            currentHp = 0;
    }

    public void UI_ON()
    {
        if (Ui_on)
        {
            UI1.SetActive(true);
            UI2.SetActive(true);
            UI3.SetActive(true);
        }
        else
        {
            UI1.SetActive(false);
            UI2.SetActive(false);
            UI3.SetActive(false);
        }
    }

    public int CheckSlimeList()
    {
        if (DataManager.dataManager.slimeNum0 < 10)
            return 0;
        else if (DataManager.dataManager.slimeNum1 < 10)
            return 1;
        else if (DataManager.dataManager.slimeNum2 < 10)
            return 2;
        else if (DataManager.dataManager.slimeNum3 < 10)
            return 3;
        else if (DataManager.dataManager.slimeNum4 < 10)
            return 4;
        else if (DataManager.dataManager.slimeNum5 < 10)
            return 5;
        else if (DataManager.dataManager.slimeNum6 < 10)
            return 6;
        else if (DataManager.dataManager.slimeNum7 < 10)
            return 7;
        else if (DataManager.dataManager.slimeNum8 < 10)
            return 8;
        else
            return 9;
    }
}
