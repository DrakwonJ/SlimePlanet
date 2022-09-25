using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InstaniateSlimeInven : MonoBehaviour
{
    public GameObject[] _slimePool;
    public GameObject dragController;
    int slimePowerSum = 0;
    int slimePowerMax = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateSlimeInven()
    {
        slimePowerSum = 0;
        slimePowerMax = 0;
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        for (int i = DataManager.dataManager.slimeCode.Count-1; i >= 0; i--)
        {
            CreateSlimeByCode(DataManager.dataManager.slimeCode[i]);
        }

        float averagePower = (float)Math.Round(((float)slimePowerSum / (float)DataManager.dataManager.slimeCode.Count), 3);
        DataManager.dataManager.SetRankingPower(slimePowerSum, slimePowerMax, averagePower);
        dragController.GetComponent<DragController>().SetDragLimit(DataManager.dataManager.slimeCode.Count);
    }

    public void CreateSlimeByCode(string code)
    {
        if (code == "string")
            return;
        int slimePool, slimeType, power, slimeListNum;
            long date;
        float r, g, b;
        slimePool = Int32.Parse(code.Substring(0, 2));
        slimeType = Int32.Parse(code.Substring(2, 1));
        r = float.Parse(code.Substring(3, 3));
        g = float.Parse(code.Substring(6, 3));
        b = float.Parse(code.Substring(9, 3));
        power = Int32.Parse(code.Substring(12, 3));
        date = long.Parse(code.Substring(15, 12));
        slimeListNum = Int32.Parse(code.Substring(27, 1));
        GameObject spawnMon;
        spawnMon = Instantiate(_slimePool[slimePool], new Vector3(0, 0, 0), _slimePool[slimePool].transform.rotation);
        spawnMon.transform.parent = this.transform;
        GameObject childObj = spawnMon.transform.GetChild(1).gameObject;
        spawnMon.GetComponent<SlimeInfo>().pool = (Define.SlimePool)slimePool;
        spawnMon.transform.rotation = Quaternion.Euler(0, 180, 0);
        spawnMon.transform.localScale = new Vector3(400, 400, 400);
        spawnMon.GetComponent<SlimeInfo>().type = (Define.SlimeType)slimeType;
        spawnMon.GetComponent<SlimeInfo>().slimeCode = code;
        spawnMon.GetComponent<SlimeInfo>().power = power;
        spawnMon.GetComponent<SlimeInfo>().spawnDate = date;
        spawnMon.GetComponent<SlimeInfo>().maxHp = power;
        spawnMon.GetComponent<SlimeInfo>().currentHp = power;
        spawnMon.GetComponent<SlimeInfo>().slimeListNum = slimeListNum;
        spawnMon.GetComponent<SlimeInfo>().Ui_on = true;
        spawnMon.GetComponent<SlimeInfo>().UI_ON();

        r /= 100;
        g /= 100;
        b /= 100;
        Color slimeColor = new Color(r, g, b);
        childObj.GetComponent<SkinnedMeshRenderer>().materials[0].color = slimeColor;
        spawnMon.GetComponent<PlanetSlime>().onPlanet = false;
        spawnMon.GetComponent<SphereCollider>().enabled = false;

        slimePowerSum += power;
        if (slimePowerMax < power)
            slimePowerMax = power;
    }
}
