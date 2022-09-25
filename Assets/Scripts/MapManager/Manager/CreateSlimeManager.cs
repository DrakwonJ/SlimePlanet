using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Define;

public class CreateSlimeManager : MonoBehaviour
{
    public static CreateSlimeManager createSlime { get; set; }
    public GameObject[] slimePool;
    public GameObject text;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (createSlime == null)
            createSlime = this;
        else if (createSlime != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public GameObject CreateSlimeByEgg(GameObject egg)
    {
        GameObject newSlime;
        float colorCoder = 0;
        float colorCodeg = 0;
        float colorCodeb = 0;

        colorCoder = Random.Range(0.0f, 1.0f);
        colorCodeg = Random.Range(0.0f, 1.0f);
        colorCodeb = Random.Range(0.0f, 1.0f);
        colorCoder = parsedot2(colorCoder);
        colorCodeg = parsedot2(colorCodeg);
        colorCodeb = parsedot2(colorCodeb);

        int slimeNum;
        int randNum = Random.Range(0, 101);
        if (randNum < 25)
            slimeNum = egg.GetComponent<EggInfo>().parentPool1;
        else if (randNum < 50)
            slimeNum = egg.GetComponent<EggInfo>().parentPool2;
        else
            slimeNum = Random.Range(0, 9);

        newSlime = Instantiate(slimePool[slimeNum], gameObject.transform);
        newSlime.GetComponent<SlimeInfo>().pool = (SlimePool)slimeNum;

        GameObject childObj = newSlime.transform.GetChild(1).gameObject;
        Material slimeMat = childObj.GetComponent<SkinnedMeshRenderer>().materials[0];
        Color slimeColor = slimeMat.color;
        slimeColor.r = colorCoder;
        slimeColor.g = colorCodeg;
        slimeColor.b = colorCodeb;
        childObj.GetComponent<SkinnedMeshRenderer>().materials[0].color = slimeColor;

        SlimeType type = Define.SlimeType.triple;
        if (colorCoder > colorCodeg && colorCoder > colorCodeb)
            type = Define.SlimeType.fire;
        else if (colorCodeg > colorCodeb && colorCodeg > colorCoder)
            type = Define.SlimeType.water;
        else if (colorCodeb > colorCoder && colorCodeb > colorCodeg)
            type = Define.SlimeType.grass;
        else if (colorCoder == colorCodeg && colorCoder != colorCodeb)
            type = Define.SlimeType.grassfire;
        else if (colorCoder == colorCodeb && colorCoder != colorCodeg)
            type = Define.SlimeType.firewater;
        else if (colorCodeg == colorCodeb && colorCodeg != colorCoder)
            type = Define.SlimeType.watergrass;
        else if (colorCodeg == colorCodeb && colorCodeb == colorCoder)
            type = Define.SlimeType.triple;

        newSlime.GetComponent<SlimeInfo>().power = egg.GetComponent<EggInfo>().potential + Random.Range(-10, 11);
        newSlime.GetComponent<SlimeInfo>().type = type;
        switch (type)
        {
            case SlimeType.firewater:
            case SlimeType.grassfire:
            case SlimeType.watergrass:
                newSlime.GetComponent<SlimeInfo>().power += 10;
                break;
            case SlimeType.triple:
                newSlime.GetComponent<SlimeInfo>().power += 20;
                break;
        }
        newSlime.GetComponent<SlimeInfo>().spawnDate = long.Parse(DateManager.dateManager.now.ToString("yyyyMMddHHmm"));
        newSlime.GetComponent<SlimeInfo>().CreateCode(colorCoder,colorCodeg,colorCodeb);
        text.GetComponent<Text>().text = "Power : " + newSlime.GetComponent<SlimeInfo>().power;
        return newSlime;
    }

    float parsedot2(float val)
    {
        var str = val.ToString("0.00");
        return float.Parse(str);
    }

}
