using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public string type;
    // Start is called before the first frame update
    void Start()
    {
        ListUpRanking();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ListUpRanking()
    {
        if(type == "average")
        {
            for(int i = 0; i < DataManager.dataManager.avgRank.Count; i++)
            {
                gameObject.transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = DataManager.dataManager.avgRank[i].nickname;
                gameObject.transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = DataManager.dataManager.avgRank[i].score;

            }
        }
        else if(type == "sum")
        {
            for (int i = 0; i < DataManager.dataManager.sumRank.Count; i++)
            {
                gameObject.transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = DataManager.dataManager.sumRank[i].nickname;
                gameObject.transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = DataManager.dataManager.sumRank[i].score;

            }
        }
        else if(type == "max")
        {
            for (int i = 0; i < DataManager.dataManager.maxRank.Count; i++)
            {
                gameObject.transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = DataManager.dataManager.maxRank[i].nickname;
                gameObject.transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = DataManager.dataManager.maxRank[i].score;

            }
        }
    }
}
