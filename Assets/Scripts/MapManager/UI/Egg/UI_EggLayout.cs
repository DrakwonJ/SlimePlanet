using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_EggLayout : MonoBehaviour
{
    int incubator;
    public GameObject incubatorImg;
    // Start is called before the first frame update
    void Start()
    {
        if (EggManager.eggManager.ready)
        {
            incubator = DataManager.dataManager.incubator;
            for (int i = 0; i < incubator; i++)
            {
                GameObject incu = Instantiate(incubatorImg, gameObject.transform);
                incu.GetComponent<UI_IncubatorSelect>().incuNum = i + 1;
                incu.transform.SetSiblingIndex(i);
            }
            List<GameObject> incuEgg = EggManager.eggManager.incubatorList;
            for(int i = 0; i < incuEgg.Count; i++)
            {
                incuEgg[i].transform.SetParent(transform.GetChild(incuEgg[i].GetComponent<EggInfo>().incubatorNum - 1));
                incuEgg[i].transform.localPosition = new Vector3(0, -150, 0);
                incuEgg[i].transform.localScale = new Vector3(400, 400, 400);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
