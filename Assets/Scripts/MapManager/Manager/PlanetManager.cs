using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlanetManager : MonoBehaviour
{
    public static PlanetManager planetManager { get; set; }
    public List<GameObject> planetPrefab = new List<GameObject>();
    public GameObject planet;
    public List<GameObject> slimeList = new List<GameObject>();
    public GameObject[] _slimePool = new GameObject[9];

    private void Awake()
    {
        if (planetManager == null)
            planetManager = this;
        else if (planetManager != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        InstantitatePlanet();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void InstantitatePlanet()
    {
        if (planet != null)
            Destroy(planet);
        planet = Instantiate(planetPrefab[0]);
        planet.transform.position = new Vector3(0, 0, 120);
        planet.transform.localScale = new Vector3(7, 7, 7);
        _slimePool = CreateSlimeManager.createSlime.slimePool;
        PlaceSlimeOnPlanet();
    }

    public void PlaceSlimeOnPlanet()
    {
        for(int i = 0; i < DataManager.dataManager.slimeCode.Count; i++)
        {
            CreateSlimeByCode(DataManager.dataManager.slimeCode[i]);
        }
    }

    public void CreateSlimeByCode(string code)
    {
        if (code == "string")
            return;
        int slimePool, slimeType, power, listNum;
        long date;
        float r, g, b;
        slimePool = Int32.Parse(code.Substring(0, 2));
        slimeType = Int32.Parse(code.Substring(2, 1));
        r = float.Parse(code.Substring(3, 3));
        g = float.Parse(code.Substring(6, 3));
        b = float.Parse(code.Substring(9, 3));
        power = Int32.Parse(code.Substring(12, 3));
        date = long.Parse(code.Substring(15, 12));
        listNum = Int32.Parse(code.Substring(27, 1));
        GameObject spawnMon;
        spawnMon = Instantiate(_slimePool[slimePool], new Vector3(0, 0, 120), _slimePool[slimePool].transform.rotation);
        spawnMon.transform.parent = planet.transform;
        GameObject childObj = spawnMon.transform.GetChild(1).gameObject;
        spawnMon.GetComponent<SlimeInfo>().pool = (Define.SlimePool)slimePool;
        spawnMon.transform.rotation = Quaternion.Euler(0, 180, 0);
        spawnMon.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        spawnMon.GetComponent<SlimeInfo>().type = (Define.SlimeType)slimeType;
        spawnMon.GetComponent<SlimeInfo>().slimeCode = code;
        spawnMon.GetComponent<SlimeInfo>().power = power;
        spawnMon.GetComponent<SlimeInfo>().spawnDate = date;
        spawnMon.GetComponent<SlimeInfo>().maxHp = power;
        spawnMon.GetComponent<SlimeInfo>().currentHp = power;
        spawnMon.GetComponent<SlimeInfo>().Ui_on = false;
        spawnMon.GetComponent<SlimeInfo>().UI_ON();
        spawnMon.GetComponent<SlimeInfo>().slimeListNum = listNum;

        spawnMon.GetComponent<Rigidbody>().isKinematic = false;
        spawnMon.GetComponent<PlanetSlime>().onPlanet = true;
        spawnMon.GetComponent<PlanetSlime>().gravityTarget = planet.transform;
        PlaceRandPosition(spawnMon);
        slimeList.Add(spawnMon);

        r /= 100;
        g /= 100;
        b /= 100;
        Color slimeColor = new Color(r, g, b);
        childObj.GetComponent<SkinnedMeshRenderer>().materials[0].color = slimeColor;
    }

    public void PlaceRandPosition(GameObject go)
    {
        go.transform.localPosition = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f), Random.Range(-1.0f, 2.0f));
    }

}
